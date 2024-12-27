using AutoMapper;
using Domain.Models.Files;
using Application.Mapping.DtoLogics.FileDtoLogics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;


namespace Application.AppServices.FilesServices;

public class FileService
{
    IFileRepository _filesRepos;
    IMapper _mapper;
    IFileLoader<FileModel> _fileLoader;
    ILogger<FileService> _logger;
    public FileService(IFileRepository filesRepository, IFileLoader<FileModel> fileLoader, 
        IMapper mapper, ILogger<FileService> logger)
    {
        _filesRepos = filesRepository;
        _mapper = mapper;
        _fileLoader = fileLoader;
        _logger = logger;
    }
    public bool LoadFile(string userKey, IFormCollection formCollection)
    {
        
        foreach (var f in formCollection.Files)
        {
            var model = new FileModel(userKey, f.Name);
            model = _filesRepos.GetEntity(model!);
            if (model == null)
            {
                var pathFile = _fileLoader.LoadFile(f, model?.UserKey!).Result;
                model?.SetFullPath(pathFile!);
                _filesRepos.AddEntity(model!);
            }
        }
        return true;
    }

    public bool DeleteFile(FileDtoLogic fileDtoLogic)
    {
        var fileModel = _mapper.Map<FileModel>(fileDtoLogic);

        _logger.LogInformation($":::TEST::: Delete Index: {fileModel.Index_UserKey_FileName}");

        fileModel = _filesRepos.GetEntity(fileModel);
        var res = false;
        if (fileModel != null)
        {
            res = _fileLoader.DeleteFile(fileModel);
            if (res)
                res = _filesRepos.DeleteEntity(fileModel);
            return res;
        }
        return res;
    }

    public string? GetFilePath(FileDtoLogic fileDtoLogic)
    {
        var fileModel = _mapper.Map<FileModel>(fileDtoLogic);

        _logger.LogInformation($":::TEST::: Get Index: {fileModel.Index_UserKey_FileName}");

        fileModel = _filesRepos.GetEntity(fileModel);

        _logger.LogInformation($":::TEST::: Get Path: {fileModel?.FullPath}");

        return fileModel?.FullPath;
    }
}

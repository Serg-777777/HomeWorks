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
    public bool LoadFile(FileDtoLogic fileDtoLogic, HttpRequest request)
    {
        var fileNew = _mapper.Map<FileModel>(fileDtoLogic);

        _logger.LogInformation($":::TEST::: Load Index: {fileNew.Index_UserKey_FileName}");

        FileModel? file = null;
        foreach (var f in request.Form.Files)
        {
            file = _filesRepos.GetEntity(fileNew!);
            if (file == null)
            {
                var pathFile = _fileLoader.LoadFile(f, fileNew?.UserKey!).Result;

                _logger.LogInformation($":::TEST::: Load pathFile: {pathFile}");

                fileNew?.SetFullPath(pathFile!);
                _filesRepos.AddEntity(fileNew!);
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

        _logger.LogInformation($":::TEST::: Service Get Index: {fileModel.Index_UserKey_FileName}");

        fileModel = _filesRepos.GetEntity(fileModel);

        _logger.LogInformation($":::TEST::: Service Get Path: {fileModel?.FullPath}");

        return fileModel?.FullPath;
    }
}

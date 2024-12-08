

using Domain.Models.Files;
using Infrastructure.Context.FilesContexts;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories.FilesRepos;

public class FileRepos : IFileRepository
{
    FileContext _fileContext;
    ILogger<FileRepos> _logger;
    public FileRepos(FileContext fileContext, ILogger<FileRepos> logger)
    {
        _fileContext = fileContext;
        _logger = logger;
    }

    public FileModel? AddEntity(FileModel entity)
    {
        var fileLoad = new FileModel(entity.UserKey!, entity.FileName!).SetFullPath(entity.FullPath!); //валидация через атрибуты в модели
        var newRecord = _fileContext.Add(fileLoad).Entity;

        _logger.LogInformation($":::TEST::: AddEntity: FileName=>{newRecord.FileName}, Index=>{newRecord.Index_UserKey_FileName}, FullPath => {newRecord.FullPath}");

        _fileContext.SaveChanges();
        return newRecord;
    }

    public bool DeleteEntity(FileModel entity)
    {
        var file = this.GetEntity(entity);

        _logger.LogInformation($":::TEST::: Delete: FileName=>{file?.FileName}, Index=>{file?.Index_UserKey_FileName}, FullPath => {file?.FullPath}");

        if (file != null)
        {
            _fileContext.FilesLibrary.Remove(file);
            _fileContext.SaveChanges();
            return true;
        }
        return false;
    }

    public FileModel? GetEntity(FileModel entity)
    {
        var file = _fileContext.FilesLibrary.FirstOrDefault(f => f.Index_UserKey_FileName == entity.Index_UserKey_FileName);

        _logger.LogInformation($":::TEST::: GetEntity: FileName=>{file?.FileName}, Index=>{file?.Index_UserKey_FileName}, FullPath => {file?.FullPath}");

        return file;
    }

}

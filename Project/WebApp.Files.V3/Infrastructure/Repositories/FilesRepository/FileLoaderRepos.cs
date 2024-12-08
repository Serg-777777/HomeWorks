using Domain.Models.Files;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace Application.AppServices.FilesServices;

public class FileLoaderRepos : IFileLoader<FileModel>
{
    string _basePath;
    ILogger<FileLoaderRepos> _logger;
    public FileLoaderRepos(IConfigurationSection pathConfig, ILogger<FileLoaderRepos> logger)
    {
        _basePath = $@"{Directory.GetCurrentDirectory()}/wwwroot/"; // из секции конфиг;
        _logger = logger;
    }
    
    public async Task<string?> LoadFile(IFormFile file, string userKey)
    {
        var path = @$"{_basePath}/{userKey}/{file.FileName}";

        _logger.LogInformation($":::TEST::: Load path: {path}");

        if (!Directory.Exists(path))
        {
            using var f = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(f);
            return path;
        }
        return null;
    }

    public bool DeleteFile(FileModel fileModel)
    {
        var path = fileModel.FullPath;

        _logger.LogInformation($":::TEST::: Delete path: {path}");

        if (Directory.Exists(path))
        {
            Directory.Delete(path);
            return true;
        }
        return false;
    }

}

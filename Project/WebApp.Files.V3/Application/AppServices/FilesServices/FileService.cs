using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;


namespace Application.AppServices.FilesServices;

public class FileService:IFileService
{
    private readonly ILoader<IFormFile, IFileInfo> _loader;
    public FileService(ILoader<IFormFile, IFileInfo> loader)
    {
        _loader = loader;
    }
    public IFileInfo? DownloadFile(string fileName, string userKey)
    {
        var file = _loader.Download(fileName, userKey);
        return file;
    }
    public bool UploadFile(IFormCollection formCollection, string userKey)
    {
        bool res = false;
        foreach (var f in formCollection.Files)
        {
            res = _loader.Upload(f, userKey);
        }
        return res;
    }

    public bool DeleteFile(string fileName, string userKey)
    {
        var res = _loader.Delete(fileName,userKey);
        return res;
    }
    public List<string>? GetFiles(string userKey)
    {
        var fs = new List<string>(); 
        var fis = _loader.Files(userKey);
        if(fis != null)
            foreach (var f in fis)
            {
                fs.Add(f.Name);
            }
        return fs;
    }
}

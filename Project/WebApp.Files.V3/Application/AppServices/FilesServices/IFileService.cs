using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;

namespace Application.AppServices.FilesServices;

public interface IFileService
{
    IFileInfo? DownloadFile(string fileName, string userKey);
    bool UploadFile(IFormCollection formCollection, string userKey);
    bool DeleteFile(string fileName, string userKey);
    List<string>? GetFiles(string userKey);
}
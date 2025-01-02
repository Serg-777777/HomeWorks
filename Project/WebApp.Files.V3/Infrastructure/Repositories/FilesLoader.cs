

using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;

namespace Infrastructure.Repositories
{
    public class FilesLoader : ILoader<IFormFile, IFileInfo>
    {
        private string _basePath;

        public FilesLoader()
        {
            _basePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot");
        }

        public bool Upload(IFormFile fileForm, string userKey)
        {
            var path = _PathCombinate(fileForm.FileName, userKey, true);
            using (var stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                fileForm.CopyTo(stream);
            }
            return true;
        }
        public IFileInfo? Download(string fileName, string userKey)
        {

            var path = Path.Combine(_basePath, userKey);
            if (path != null)
            {
                var provider = new PhysicalFileProvider(path);
                var fi = provider.GetFileInfo(fileName);
                return fi;
            }
            return null;
        }
        public bool Delete(string fileName, string userKey)
        {
            var path = _PathCombinate(fileName, userKey);
            if(path != null)
            {
                Directory.Delete(path);
                return true;
            }
            return false;
        }
        private string _PathCombinate(string fileName, string userKey, bool toAdd = false)
        {
            var path = Path.Combine(_basePath, userKey);
            if (toAdd = true && !Directory.Exists(path))
                Directory.CreateDirectory(path);
            path = Path.Combine(path, fileName);
            return path;
        }

     
    }
}

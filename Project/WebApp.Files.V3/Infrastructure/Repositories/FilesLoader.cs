

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
            var path = _PathFileInitialize(fileForm.FileName, userKey, true);
            using (var stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                fileForm.CopyTo(stream);
            }
            return true;
        }

        public List<FileInfo>? Files(string userKey)
        {
            var files = new List<FileInfo>();
            var path = Path.Combine(_basePath, userKey);
            if(Directory.Exists(path))
            {
                var fs = Directory.GetFiles(path);
                foreach(var f in fs)
                {
                    var fi = new FileInfo(f);
                    files.Add(fi);
                }    
            }
            return files;
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
            var path = _PathFileInitialize(fileName, userKey);
            if(path != null)
            {
                File.Delete(path);
                return true;
            }
            return false;
        }
        private string _PathFileInitialize(string fileName, string userKey, bool toAdd = false)
        {
            var path = Path.Combine(_basePath, userKey);
            if (toAdd = true && !Directory.Exists(path))
                Directory.CreateDirectory(path);
            path = Path.Combine(path, fileName);
            return path;
        }
    }
}

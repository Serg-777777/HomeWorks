
using Microsoft.AspNetCore.Http;

namespace Domain.Models;

public interface ILoader<TModel, out TFile > where TModel: class where TFile: class
{
    bool Upload(TModel entity, string userKey);
    TFile? Download(string fileName, string userKey);
    bool Delete(string fileName, string userKey);
     List<FileInfo>? Files(string userKey);
}

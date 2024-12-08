
using Microsoft.AspNetCore.Http;

namespace Domain.Models.Files;

public interface IFileLoader<TEntity> where TEntity: EntityBase
{
    public Task<string?> LoadFile(IFormFile file, string userKey);
    public bool DeleteFile(TEntity entity);
}

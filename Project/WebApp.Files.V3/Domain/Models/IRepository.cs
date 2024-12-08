

using Domain.Models.Files;

namespace Domain.Models;

public interface IRepository<TModel> where TModel : EntityBase
{
    TModel? AddEntity(TModel entity);
    bool DeleteEntity(TModel entity);
    FileModel? GetEntity(FileModel entity);
}

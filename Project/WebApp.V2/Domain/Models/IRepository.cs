

namespace Domain.Models;
   
public interface IRepository<TEntity, TValueID> where TEntity : IEntity
{
    Task<TEntity>? GetEntityAsync(TValueID entityID);
    Task<TEntity>? AddEntityAsync(TEntity entity);
    Task<bool> RemoveEntityAsync(TValueID entityID);
    Task<TEntity>? UpdateEntityAsync(TValueID entityID, TEntity entity);
    Task<List<TEntity>> EntitiesAsync();
}


namespace Domain.Models;
   
public interface IRepository<TEntity, TValueID> where TEntity : IEntity
{
    TEntity? GetEntity(TValueID entityID);
    bool AddEntity(TEntity entity);
    bool RemoveEntity(TValueID entityID);
    TEntity UpdateEntity(TValueID entityID, TEntity entity);
    IQueryable<TEntity> Entities { get; }
}
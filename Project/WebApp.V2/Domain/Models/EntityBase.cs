

namespace Domain.Models;

public abstract partial class EntityBase<TEntity>: IEquatable<TEntity> where TEntity : IEntity
{
    protected Lazy<ICollection<TEntity>> _entities = new();
    public IReadOnlyCollection<TEntity> Entities() => (IReadOnlyCollection<TEntity>) _entities.Value.AsQueryable();
    protected TEntity AddEntity(TEntity entity)
    {
        if(!_entities.Value.Contains(entity))
        _entities.Value.Add(entity);
        return entity; 
    }
    protected bool RemoveEntity(TEntity entity)
    {
        if (_entities.Value.Contains(entity))
            return _entities.Value.Remove(entity);
        return false;
    }
    public abstract bool Equals(TEntity? other);
}
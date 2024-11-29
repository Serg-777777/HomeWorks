﻿

namespace Domain.Models;

public interface IRepositoryCRUD<TEntity> where TEntity : IEntity
{
    TEntity? GetEntity(int id);
    bool AddEntity(TEntity entity);
    bool RemoveEntity(int entityID);
    TEntity UpdateEntity(TEntity entity);
    IReadOnlyCollection<TEntity> Entities { get; }
}
namespace Domain.Models;

public interface IEntityVisitor<TEntity> where TEntity : IEntity
{
    object Excute(IReadOnlyCollection<TEntity> readOnlyConnection);
}

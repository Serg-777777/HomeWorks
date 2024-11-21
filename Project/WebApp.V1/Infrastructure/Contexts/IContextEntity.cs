

using Domain;

namespace Infrastructure.Contexts
{
    internal interface IContextEntity<TEntity> where TEntity : IEntity
    {
        public IQueryable<TEntity>  Entities { get; }
    }
}

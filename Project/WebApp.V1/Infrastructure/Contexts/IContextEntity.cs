

using Domain;

namespace Infrastructure.Contexts
{
    internal interface IContextEntity<TEntity> where TEntity : IEntity
    {
        public ICollection<TEntity> Entities { get; set; }
    }
}

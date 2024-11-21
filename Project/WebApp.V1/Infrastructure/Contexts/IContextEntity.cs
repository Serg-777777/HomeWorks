

using Domain;

namespace Infrastructure.Contexts
{
    internal interface IContextEntity<TEntity> where TEntity : IEntity
    {
        public List<TEntity> Entities { get; set; }
    }
}

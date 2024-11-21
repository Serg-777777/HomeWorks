using Domain;

namespace Infrastructure.Repositories
{
    internal interface IRepositoryModel<TModel> where TModel: IEntity
    {
        TModel GetEntity(int id);
        bool AddEntity(TModel model);
        bool UpdateEntity(TModel model);
        bool RemoveEntity(int id);
        IReadOnlyCollection<TModel> Entities();
    }
}
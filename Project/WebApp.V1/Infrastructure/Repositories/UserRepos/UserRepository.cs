using Domain.Models.UserModel;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories.UserRepository
{
    internal class UserRepository : IRepositoryModel<UserModel>
    {
        protected IContextEntity<UserModel> _entities;
        public UserRepository(IContextEntity<UserModel> entities)
        {
            _entities = entities;
        }
        public bool AddEntity(UserModel model)
        {
            _entities.Entities.Add(model);
            return true;
        }

        public IReadOnlyCollection<UserModel> Entities() => (IReadOnlyCollection <UserModel>)_entities.Entities;

        public UserModel GetEntity(int id)
        {
            var e = _entities.Entities.FirstOrDefault(p => p.Id == id);
            return e!;
        }

        public bool RemoveEntity(int id)
        {
            var e = _entities.Entities.FirstOrDefault(p => p.Id == id);
            return true;
        }

        public bool UpdateEntity(UserModel model)
        {
            var e = _entities.Entities.FirstOrDefault(p => p.Id == model.Id);
            e = model;
            return true;
        }
    }
}

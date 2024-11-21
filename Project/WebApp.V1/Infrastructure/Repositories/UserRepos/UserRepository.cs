using Domain.Models.UserModel;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories.UserRepository
{
    internal class UserRepository : IRepositoryModel<UserModel>
    {
        List<UserModel> _entities;
        public UserRepository(IContextEntity<UserModel> entities)
        {
            _entities = entities.Entities;
        }
        public UserModel AddEntity(UserModel model)
        {
            _entities.Add(model);
            return model;
        }

        public IReadOnlyCollection<UserModel> Entities() => _entities;

        public UserModel GetEntity(int id)
        {
            var e = _entities.FirstOrDefault(p => p.Id == id);
            return e!;
        }

        public bool RemoveEntity(int id)
        {
            var e = _entities.FirstOrDefault(p => p.Id == id);
            return true;
        }

        public bool UpdateEntity(UserModel model)
        {
            var e = _entities.FirstOrDefault(p => p.Id == model.Id);
            e = model;
            return true;
        }
    }
}

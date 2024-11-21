
using Domain.Models.UserModel;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories.UserRepository
{
    internal class UserProfileRepository : IRepositoryModel<UserProfileModel>
    {

        public UserProfileModel AddEntity(UserProfileModel model)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<UserProfileModel> Entities()
        {
            throw new NotImplementedException();
        }

        public UserProfileModel GetEntity(int id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveEntity(UserProfileModel model)
        {
            throw new NotImplementedException();
        }

        public bool UpdateEntity(UserProfileModel model)
        {
            throw new NotImplementedException();
        }
    }
}

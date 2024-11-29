

using Domain.Models.UserModels;

namespace Infrastructure.Repositories.UserRepos
{
    sealed public class UserProfileRepository : IUserProfileRepository
    {
        ICollection<UserProfileModel> _profiles;
        public UserProfileRepository(ICollection<UserProfileModel> profiles)
        {
            _profiles = profiles;
        }

        public IReadOnlyCollection<UserProfileModel> Entities => _profiles.ToList();

        public bool AddEntity(UserProfileModel entity)
        {
            throw new NotImplementedException();
        }

        public UserProfileModel GetEntity(int id)
        {
            throw new NotImplementedException();
        }

        public UserSettingModel? GetSettingsByUserId(int idUser)
        {
            throw new NotImplementedException();
        }

        public bool RemoveEntity(int entityID)
        {
            throw new NotImplementedException();
        }

        public UserProfileModel UpdateEntity(UserProfileModel entity)
        {
            throw new NotImplementedException();
        }


    }
}

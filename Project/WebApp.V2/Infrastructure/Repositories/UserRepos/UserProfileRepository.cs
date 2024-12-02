

using Domain.Models.UserModels;
using Infrastructure.Contexts.UserContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.UserRepos
{
    sealed public class UserProfileRepository : IUserProfileRepository
    {
        DbSet<UserProfileModel>  _profiles;
        public UserProfileRepository(UserContext userContext)
        {
            _profiles = userContext.UserProfiles;
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



using Domain.Models.UserModels;
using Infrastructure.Contexts.UserContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.UserRepos
{
    sealed public class UserProfileRepository : IUserProfileRepository
    {
        DbSet<UserProfileModel> _profiles;
        public UserProfileRepository(UserContext userContext)
        {
            _profiles = userContext.UserProfiles;
        }

        public IQueryable<UserProfileModel> Entities => _profiles.AsQueryable();

        public bool AddEntity(UserProfileModel entity)
        {
            throw new NotImplementedException();
        }

        public UserProfileModel? GetEntity(string entityID)
        {
            throw new NotImplementedException();
        }

        public UserSettingModel? GetSettingsByUserId(string idUser)
        {
            throw new NotImplementedException();
        }

        public bool RemoveEntity(string entityID)
        {
            throw new NotImplementedException();
        }

        public UserProfileModel UpdateEntity(string entityID, UserProfileModel entity)
        {
            throw new NotImplementedException();
        }
    }
}

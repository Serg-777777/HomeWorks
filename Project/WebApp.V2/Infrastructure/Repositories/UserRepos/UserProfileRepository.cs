

using Domain.Models.UserModels;
using Infrastructure.Contexts.UserContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.UserRepos
{
    sealed public class UserProfileRepository
    {
        DbSet<UserProfileModel> _profiles=default!;
        public UserProfileRepository(UserContext userContext)
        {
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

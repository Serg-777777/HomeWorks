

using Domain.Models.UserModels;
using Infrastructure.Contexts.UserContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.UserRepos
{
    sealed public class UserSettingRepository
    {
        DbSet<UserSettingModel> _settings=default!;
        public UserSettingRepository(UserContext userContext)
        {
        }

        public IQueryable<UserSettingModel> Entities => _settings.AsQueryable();

        public bool AddEntity(UserSettingModel entity)
        {
            throw new NotImplementedException();
        }

        public UserSettingModel? GetEntity(string entityID)
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

        public UserSettingModel UpdateEntity(string entityID, UserSettingModel entity)
        {
            throw new NotImplementedException();
        }
    }
}

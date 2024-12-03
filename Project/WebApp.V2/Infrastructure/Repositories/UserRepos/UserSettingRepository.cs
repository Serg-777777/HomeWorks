

using Domain.Models.UserModels;
using Infrastructure.Contexts.UserContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.UserRepos
{
    sealed public class UserSettingRepository : IUserSettingsRepository
    {
        DbSet<UserSettingModel> _settings;
        public UserSettingRepository(UserContext userContext)
        {
            _settings = userContext.UserSettings;
        }

        public IReadOnlyCollection<UserSettingModel> Entities => _settings.ToList();

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

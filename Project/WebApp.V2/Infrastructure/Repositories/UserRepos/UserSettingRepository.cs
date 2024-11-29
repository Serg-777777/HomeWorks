

using Domain.Models.UserModels;

namespace Infrastructure.Repositories.UserRepos
{
    sealed public class UserSettingRepository : IUserSettingsRepository
    {
        ICollection<UserSettingModel> _settings;
        public UserSettingRepository(ICollection<UserSettingModel> settings)
        {
            _settings = settings;
        }

        public IReadOnlyCollection<UserSettingModel> Entities => _settings.ToList();

        public bool AddEntity(UserSettingModel entity)
        {
            throw new NotImplementedException();
        }

        public UserSettingModel? GetEntity(int id)
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

        public UserSettingModel UpdateEntity(UserSettingModel entity)
        {
            throw new NotImplementedException();
        }
    }
}

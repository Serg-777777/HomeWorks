

using Domain.Models.UserModels;

namespace Infrastructure.Repositories.UserRepos
{
    sealed public partial class UserSettingRepository : IUserSettingsRepository<UserSettingModel>
    {
        public UserSettingModel? GetSettingsByUserId(int idUser)
        {
            var settings = new UserSettingModel().Entities().FirstOrDefault(s=>s.UserModelId==idUser);
            return settings;
        }

        public bool UpdateSettingsByUserId(int idUser, bool isLoadFiles, bool isDownLoadFiles)
        {
            var res = new UserSettingModel().UpdateValues(idUser,isLoadFiles, isDownLoadFiles);
            return res;
        }
    }
}

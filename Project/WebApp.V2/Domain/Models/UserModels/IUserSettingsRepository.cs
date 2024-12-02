

namespace Domain.Models.UserModels
{
    public partial interface IUserSettingsRepository : IRepository<UserSettingModel>
    {
        UserSettingModel? GetSettingsByUserId(int idUser);
    }
}

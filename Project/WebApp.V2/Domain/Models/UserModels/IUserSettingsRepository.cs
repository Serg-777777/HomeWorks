

namespace Domain.Models.UserModels
{
    public partial interface IUserSettingsRepository : IRepository<UserSettingModel, string>
    {
        UserSettingModel? GetSettingsByUserId(string idUser);
    }
}

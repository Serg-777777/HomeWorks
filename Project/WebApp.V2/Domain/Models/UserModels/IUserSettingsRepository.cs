

namespace Domain.Models.UserModels
{
    public partial interface IUserSettingsRepository : IRepositoryCRUD<UserSettingModel>
    {
        UserSettingModel? GetSettingsByUserId(int idUser);
    }
}

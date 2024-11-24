

namespace Domain.Models.UserModels
{
    public partial interface IUserSettingsRepository<TBaseModel> where TBaseModel : EntityBase<UserSettingModel>
    {
        UserSettingModel? GetSettingsByUserId(int idUser);
        bool UpdateSettingsByUserId(int idUser, bool isLoadFiles, bool isDownLoadFiles);
    }
}

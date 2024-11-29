

namespace Domain.Models.UserModels
{
    public interface IUserProfileRepository : IRepositoryCRUD<UserProfileModel>
    {
        UserSettingModel? GetSettingsByUserId(int idUser);
    }
}



namespace Domain.Models.UserModels
{
    public interface IUserProfileRepository : IRepository<UserProfileModel>
    {
        UserSettingModel? GetSettingsByUserId(int idUser);
    }
}

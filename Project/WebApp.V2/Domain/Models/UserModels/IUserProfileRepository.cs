

namespace Domain.Models.UserModels
{
    public interface IUserProfileRepository : IRepository<UserProfileModel, string>
    {
        UserSettingModel? GetSettingsByUserId(string idUser);
    }
}

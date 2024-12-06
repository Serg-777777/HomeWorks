
using Domain.Models;
using Domain.Models.UserModels;

namespace Infrastructure.Repositories.UserRepos;

public interface IUserRepository : IRepository<UserModel, int>
{
    UserProfileModel? GetProfile(int id);
    UserProfileModel? GetProfile(string loginUser);
    UserSettingModel? GetSetting(int id);
    UserProfileModel? UpdateProfile(int id, UserProfileModel userProfile);
    UserSettingModel? UpdateSetting(int id, UserSettingModel userSetting);
}

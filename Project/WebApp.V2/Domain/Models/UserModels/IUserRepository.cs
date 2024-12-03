
using Domain.Models;
using Domain.Models.UserModels;

namespace Infrastructure.Repositories.UserRepos;

public interface IUserRepository : IRepository<UserModel, string>
{
    UserProfileModel? GetProfile(string login);
    UserSettingModel? GetSetting(string login);
    UserProfileModel? UpdateProfile(string userLogin, UserProfileModel userProfile);
    UserSettingModel? UpdateSetting(string userLogin, UserSettingModel userSetting);
}

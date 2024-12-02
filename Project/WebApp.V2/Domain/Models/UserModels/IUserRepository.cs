
using Domain.Models;
using Domain.Models.UserModels;

namespace Infrastructure.Repositories.UserRepos;

public interface IUserRepository : IRepository<UserModel>
{
    UserModel? GetEntity(string login);
    UserProfileModel? GetProfile(int idUser);
    UserSettingModel? UpdateSetting(int idUser, UserSettingModel userSetting);
    bool RemoveEntity(string login);

}

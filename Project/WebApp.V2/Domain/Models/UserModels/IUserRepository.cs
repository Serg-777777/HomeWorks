
using Domain.Models;
using Domain.Models.UserModels;

namespace Infrastructure.Repositories.UserRepos;

public interface IUserRepository : IRepositoryCRUD<UserModel>
{
    UserModel? GetEntity(string login);
    UserProfileModel? GetProfileUserByLogin(string login);
    UserSettingModel? GetSettingUserByLogin(string login);
    bool RemoveEntity(string login);

}


using Domain.Models.UserModels;

namespace Infrastructure.Repositories.UserRepos;

public class UserRepository : IUserRepository<UserModel>
{

    public UserModel CreateUser(int idUser, int idProfile, int idSettings,
       string Login, string Password, string Email,
        string? FirstName, string? LastName, string? Country, string? City, int? Age)
    {
        var setting = new UserSettingModel(idSettings, false, true, idUser);
        var profile = new UserProfileModel(idProfile, FirstName, LastName, Country, City, Age, idUser);
        var role = new UserRoleModel() { RoleUser = "пользователь" };
        var user = new UserModel(idUser, false, Login, Password!, Email!, profile, setting, role);
        
        if(user.AddUser()) return user;
        throw new ArgumentNullException(user.Login, "Пользователь не добавлен");
    }

    public UserModel? GetUserByLogin(string login)
    {
       var user = new UserModel(login);
        return user;
    }

    public UserProfileModel? GetProfileUserByLogin(string login)
    {
        var profile = new UserModel(login).UserProfile;
        return profile;
    }

    public bool RemoveUserByLogin(string login)
    {
        var user = new UserModel(login);
        if(user.RemoveUser())
        return true;
        throw new ArgumentNullException(login, "Пользователь не удалён");
    }



}


using Domain.Models;
using Domain.Models.UserModels;

namespace Infrastructure.Repositories.UserRepos;

public partial interface IUserRepository<TBaseModel> where TBaseModel : EntityBase<UserModel>
{
    UserModel? GetUserByLogin(string login);
    UserProfileModel? GetProfileUserByLogin(string login);
    bool RemoveUserByLogin(string login);
    UserModel CreateUser(int idUser, int idProfile, int idSettings,
       string Login, string Password, string Email,
       string? FirstName, string? LastName, string? Country, string? City, int? Age);
}

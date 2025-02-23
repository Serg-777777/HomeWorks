
using Domain.Models;
using Domain.Models.UserModels;

namespace Infrastructure.Repositories.UserRepos;

public interface IUserRepository : IRepository<UserModel, int>
{
    public Task<bool> EraseEntityAsync(int idUser);
    public Task<UserModel>? AuthorizeAsync(string login, string password);
    public Task<UserModel>? GetEntityByLoginAsync(string login);
}

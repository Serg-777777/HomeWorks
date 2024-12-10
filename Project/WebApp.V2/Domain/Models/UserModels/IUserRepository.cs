
using Domain.Models;
using Domain.Models.UserModels;

namespace Infrastructure.Repositories.UserRepos;

public interface IUserRepository : IRepository<UserModel, int>
{
    
}

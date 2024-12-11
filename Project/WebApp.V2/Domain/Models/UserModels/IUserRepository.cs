
using Domain.Models;
using Domain.Models.UserModels;

namespace Infrastructure.Repositories.UserRepos;

public interface IUserRepository : IRepository<UserModel, int>
{
    public bool UpdateEntityRange(IEnumerable<UserModel> userModels);
    public bool EraseEntity(int idUser);
}

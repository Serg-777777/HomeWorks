
using Domain.Models.UserModels;
using Infrastructure.Contexts.UserContexts;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories.UserRepos;

sealed public class UserRepository : IUserRepository
{
    UserContext _userContext = default!;
    ILogger<UserRepository> _logger;
    public UserRepository(UserContext userContext, ILogger<UserRepository> logger)
    {
        _userContext = userContext;
        _logger = logger;
    }

    public List<UserModel> Entities => _userContext.Users.ToList();

    public UserModel? AddEntity(UserModel entity)
    {
        var role = new UserRoleModel() { RoleUser = "гость" };
        var user = new UserModel(entity.Login!, entity.Password!, entity.Email!, entity.DateCreated, role);
        var newUser = _userContext.Users.Add(user).Entity;
        _userContext.SaveChanges();
        _logger.LogInformation($":::TEST AddEntity Login:{newUser.Login}, Email:{newUser.Email} Date: {newUser.DateCreated}");
        return newUser;
    }
    public UserModel? GetEntity(int userId)
    {
        var user = this._UserById(userId);
        return user;
    }
    public UserModel? UpdateEntity(int userId, UserModel entity)
    {
        var user = this._UserById(userId);
        _logger.LogInformation($":::TEST user Login:{entity.Login}, Email:{entity.Email}");
        if (user != null)
        {
            _userContext.Update(user.SetValues(entity));
            _userContext.SaveChanges();
            _logger.LogInformation($":::TEST user UPDATED Id:{user.Id}, Login:{user.Login}, Email:{user.Email} Date: {user.DateCreated}");
            return user;
        }
        return null!;
    }
    public bool RemoveEntity(int userId)
    {
        var user = this._UserById(userId);
        if (user != null)
        {
            user.SetIsDelete(true);
            _userContext.Users.Update(user);
            _userContext.SaveChanges();
            return true;
        }
        return false;
    }
    private UserModel? _UserById(int idUser)
    {
        var user = _userContext.Users.FirstOrDefault(u => u.Id == idUser);
        return user;
    }

    public bool UpdateEntityRange(IEnumerable<UserModel> userModels)
    {
        _userContext.Users.UpdateRange(userModels);
        _userContext.SaveChanges();
        return true;
    }

    public bool EraseEntity(int idUser)
    {
        var u = _UserById(idUser);
        _userContext.Users.Remove(u!);
        _userContext.SaveChanges();
        return true;
    }
}
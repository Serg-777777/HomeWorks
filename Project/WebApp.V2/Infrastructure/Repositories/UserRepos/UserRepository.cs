
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
        var prof = new UserProfileModel();
        var user = new UserModel(entity.Login!, entity.Password!, entity.Email!, entity.DateCreated, role, prof);
        var newUser = _userContext.Users.Add(user).Entity;

      //  prof.SetUserProperty(newUser);
        _userContext.Profiles.Add(prof);
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
        _logger.LogInformation($":::TEST REPOS Login:{entity.Login}, Role:{entity.Role?.RoleUser}");
        if (user != null && user.Id == entity.Id)
        {
            user = _userContext.Update(user.SetValues(entity)).Entity;
            _userContext.SaveChanges();
            _logger.LogInformation($":::TEST Id:{user.Id}, Login:{user.Login}, Email:{user.Email} Date: {user.DateCreated}");
            return user;
        }
        return null!;
    }
    public bool RemoveEntity(int userId)
    {
        var user = this._UserById(userId);
        if (user != null)
        {
            user.SetIsDelete(!user.IsDeleted);

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

    public bool UpdateEntityRange(List<UserModel> userModels)
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

    public UserModel? Authorize(string login, string password)
    {
        var user = _userContext.Users.FirstOrDefault(u => u.Login == login && u.Password == password);
        return user;
    }
}
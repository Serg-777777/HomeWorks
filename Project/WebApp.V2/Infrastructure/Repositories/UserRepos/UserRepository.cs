
using Domain.Models.UserModels;
using Infrastructure.Contexts.UserContexts;
using Microsoft.EntityFrameworkCore;
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

    public List<UserModel> Entities => _userContext.Users.AsNoTracking().ToList();
    public UserModel? Authorize(string login, string password)
    {
        var user = _userContext.Users.Include(p => p.Profile).FirstOrDefault(u => u.Login == login && u.Password == password);
        return user;
    }
    public UserModel? AddEntity(UserModel entity)
    {
        var newUser = _userContext.Users.Add(entity).Entity;
        _userContext.Profiles.Add(entity.Profile!);
        _userContext.SaveChanges();
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
        if (user != null && user.Id == entity.Id)
        {
            user = _userContext.Update(user.SetValues(entity)).Entity;
            _userContext.SaveChanges();
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
        var user = _userContext.Users.Include(u=>u.Profile).FirstOrDefault(u => u.Id == idUser);
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
}
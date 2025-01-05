
using Domain.Models.UserModels;
using Infrastructure.Contexts.UserContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories.UserRepos;

sealed public class UserRepository : IUserRepository
{
    UserContext _userContext = default!;
    public UserRepository(UserContext userContext)
    {
        _userContext = userContext;
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
    public UserModel? GetEntity(int idUser)
    {
        var user = _userContext.Users.Include(u => u.Profile).FirstOrDefault(u => u.Id == idUser);
        return user;
    }
    public UserModel? UpdateEntity(int userId, UserModel entity)
    {
        var user = GetEntity(userId);
        if (user != null)
        {
            user = _userContext.Update(user.SetEditValues(entity)).Entity;
            _userContext.SaveChanges();
            return user;
        }
        return null!;
    }
    public bool RemoveEntity(int userId)
    {
        var user = GetEntity(userId);
        if (user != null)
        {
            user.SetIsDelete(!user.IsDeleted);
            _userContext.Users.Update(user);
            _userContext.SaveChanges();
            return true;
        }
        return false;
    }
    public bool UpdateEntityRange(List<UserModel> userModels)
    {
        _userContext.Users.UpdateRange(userModels);
        _userContext.SaveChanges();
        return true;
    }

    public bool EraseEntity(int idUser)
    {
        var u = GetEntity(idUser);
        _userContext.Users.Remove(u!);
        _userContext.SaveChanges();
        return true;
    }
}
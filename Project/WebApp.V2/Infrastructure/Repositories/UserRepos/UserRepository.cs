
using Domain.Models.UserModels;
using Infrastructure.Contexts.UserContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.UserRepos;

sealed public class UserRepository : IUserRepository
{
    UserContext _userContext = default!;

    public UserRepository(UserContext userContext)
    {
        _userContext = userContext;
    }

    public async Task<List<UserModel>> EntitiesAsync()
    {
        var list = await _userContext.Users.AsNoTracking().ToListAsync();
        return list;
    }
    public async Task<UserModel> AuthorizeAsync(string login, string password)
    {
        var user = await _userContext.Users.Include(p => p.Profile).FirstOrDefaultAsync(u => u.Login == login && u.Password == password);
        return user!;
    }
    public async Task<UserModel>? AddEntityAsync(UserModel entity)
    {
        var obj = await GetEntityByLoginAsync(entity.Login!)!;
        if (obj != default!) return null!;

        var newUserEntity = await _userContext.Users.AddAsync(entity);
        var newUser = newUserEntity.Entity;
        _userContext.Profiles.Add(entity.Profile!);
        await _userContext.SaveChangesAsync();
        return newUser;
    }
    public async Task<UserModel>? GetEntityAsync(int idUser)
    {
        var user = await _userContext.Users.Include(u => u.Profile).FirstOrDefaultAsync(u => u.Id == idUser);
        return user!;
    }
    public async Task<UserModel>? UpdateEntityAsync(int userId, UserModel entity)
    {
        var user = await GetEntityAsync(userId)!;
        if (user != default!)
        {
            user = _userContext.Update(user.SetEditValues(entity)).Entity;
            await _userContext.SaveChangesAsync();
            return user;
        }
        return null!;
    }
    public async Task<bool> RemoveEntityAsync(int userId)
    {
        var user = await GetEntityAsync(userId)!;
        if (user != default!)
        {
            user.SetIsDelete(!user.IsDeleted);
            _userContext.Users.Update(user);
            await _userContext.SaveChangesAsync();
            return true;
        }
        return false;
    }
    public async Task<bool> EraseEntityAsync(int idUser)
    {
        var u = await GetEntityAsync(idUser)!;
        _userContext.Users.Remove(u!);
        await _userContext.SaveChangesAsync();
        return true;
    }
    public async Task<UserModel>? GetEntityByLoginAsync(string login)
    {
        var model = await _userContext.Users.FirstOrDefaultAsync(u => u.Login == login);
        return model!;
    }
}

using Domain.Models;
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
    public IReadOnlyCollection<UserModel> Entities => (IReadOnlyCollection<UserModel>)_userContext.Users.AsNoTracking().AsQueryable();

    public bool AddEntity(UserModel entity)
    {
        _userContext.Users.Add(entity);
        _userContext.UserProfiles.Add(entity.UserProfile!);
        _userContext.UserSettings.Add(entity.UserSetting!);
        _userContext.SaveChanges();

        return true;
    }

    public UserModel? GetEntity(string login)
    {
        var user = _userContext.Users.AsNoTracking().FirstOrDefault(u => u.Login == login);
        return user;
    }
    public UserProfileModel? GetProfile(string login)
    {
        var profile = _userContext.UserProfiles.AsNoTracking().FirstOrDefault(p => p.UserLoginKey == login);
        return profile;
    }
    public UserSettingModel? GetSetting(string login)
    {
        var settings = _userContext.UserSettings.FirstOrDefault(s => s.UserLoginKey == login);
        return settings;
    }

    public UserModel UpdateEntity(string entityID, UserModel entity)
    {
        var user = GetEntity(entityID);
        _userContext.Users.Update(entity);
        _userContext.SaveChanges();
        return user!;
    }
    public UserProfileModel? UpdateProfile(string userLogin, UserProfileModel userProfile)
    {
        var profile = _userContext.UserProfiles.FirstOrDefault(p => p.UserLoginKey == userLogin);
        profile?.SetValues(userProfile);
        _userContext.UserProfiles.Update(profile!);
        _userContext.SaveChanges();

        return userProfile;
    }
    public UserSettingModel? UpdateSetting(string userLogin, UserSettingModel userSetting)
    {
        throw new NotImplementedException();
    }
    public bool RemoveEntity(string login)
    {
        var u = _userContext.Users.FirstOrDefault(u => u.Login == login);
        u?.SetDelete(true);
        _userContext?.Update(u!);
        return true;
    }

}

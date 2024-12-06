
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

    public IQueryable<UserModel> Entities => _userContext.Users.AsQueryable();

    public bool AddEntity(UserModel entity)
    {
        //   using (var trans = _userContext.Database.BeginTransaction())
        //  {
        var u = _userContext.Users.Add(entity);
        //устанавливает ключи
        u.Entity.UserProfile!.SetUserProperty(u.Entity);
        u.Entity.UserSetting!.SetUserProperty(u.Entity);
        u.Entity.UserProfile!.UserModelId = (int)u.Entity?.Id!;
        u.Entity.UserSetting!.UserModelId = (int)u.Entity?.Id!;

        _userContext.UserProfiles.Add(u.Entity?.UserProfile!);
        _userContext.UserSettings.Add(u.Entity?.UserSetting!);
        _userContext.SaveChanges();
        //     trans.Commit();
        //   }
        _logger.LogInformation($":::TEST REPOS AddEntity::: Login:{u?.Entity?.Login}, Name:{u?.Entity?.UserProfile?.FirstName} Date: {u?.Entity?.UserSetting?.UserModel?.DateCreated}");

        return true;
    }

    public UserModel? GetEntity(int userId)
    {
        var user = _userContext.Users.AsNoTracking().FirstOrDefault(u => u.Id == userId);
        return user;
    }
    public UserProfileModel? GetProfile(string loginUser)
    {
        var profile = _userContext.Users.FirstOrDefault(u => u.Login == loginUser)?.UserProfile;
        return profile;
    }
    public UserProfileModel? GetProfile(int userId)
    {
        var profile = _userContext.UserProfiles.AsNoTracking().FirstOrDefault(p => p.UserModelId == userId);
        return profile;
    }
    public UserSettingModel? GetSetting(int userId)
    {
        var settings = _userContext.UserSettings.FirstOrDefault(s => s.UserModelId == userId);
        return settings;
    }

    public UserModel UpdateEntity(int userId, UserModel entity)
    {
        var user = GetEntity(userId)!
            .SetLogin(entity.Login!)
            .SetPassword(entity.Password!)
            .SetEmail(entity.Email!);
        _userContext.Users.Update(user);
        _userContext.SaveChanges();
        return user!;
    }
    public UserProfileModel? UpdateProfile(int userId, UserProfileModel userProfile)
    {
        var profile = _userContext.UserProfiles.FirstOrDefault(p => p.UserModelId == userId);
        profile?.SetValues(userProfile);
        _userContext.UserProfiles.Update(profile!);
        _userContext.SaveChanges();
        return profile;
    }
    public UserSettingModel? UpdateSetting(int userId, UserSettingModel userSetting)
    {
        var setting = _userContext.UserSettings.FirstOrDefault(s => s.UserModelId == userId);
        setting?.SetValues(userSetting);
        _userContext.UserSettings.Update(setting!);
        _userContext.SaveChanges();
        return setting;

    }
    public bool RemoveEntity(int userId)
    {
        var u = _userContext.Users.FirstOrDefault(u => u.Id == userId);
        u?.SetDelete(true);
        _userContext?.Update(u!);
        return true;
    }

}

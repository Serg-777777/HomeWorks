
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
    public IReadOnlyCollection<UserModel> Entities => (IReadOnlyCollection<UserModel>) _userContext.Users.AsNoTracking().AsQueryable();

    public bool AddEntity(UserModel entity)
    {
        var newUser = _userContext.Users.Add(entity);
        _userContext.SaveChanges();
        
        return true;
    }
    public UserModel? GetEntity(string login)
    {
       var user = _userContext.Users.AsNoTracking().FirstOrDefault(u => u.Login == login);
        return user;
    }
    public UserModel UpdateEntity(UserModel entity)
    {
        var user = GetEntity(entity.Login);
        _userContext.Users.Update(entity);
        _userContext.SaveChanges();
        return user!;
    }
    public UserProfileModel? GetProfile(int idUser)
    {
        var profile = _userContext.UserProfiles.AsNoTracking().FirstOrDefault(p => p.UserModelId == idUser);
        return profile;
    }
    public UserProfileModel? UpdateProfile(int userID, UserProfileModel userProfile)
    {
        var profile = _userContext.UserProfiles.FirstOrDefault(p => p.UserModelId == userID);
        profile?.SetValues(userProfile);
        _userContext.UserProfiles.Update(profile!);
        _userContext.SaveChanges();

        return userProfile;
    }


    //не настроены
    public UserSettingModel? UpdateSetting(int userID, UserSettingModel userSetting)
    {
        throw new NotImplementedException();
    }
    public UserModel? GetEntity(int userId)
    {
        throw new NotImplementedException();
    }
    public bool RemoveEntity(int userID)
    {
        throw new NotImplementedException();
    }
    public bool RemoveEntity(string login)
    {
        throw new NotImplementedException();
    }
    public object GetReport(IEntityVisitor<UserModel> entityVisitor)
    {
        return entityVisitor.Excute((IReadOnlyCollection<UserModel>) this.Entities.Select(p => p.IsDeleted == false));
    }
}

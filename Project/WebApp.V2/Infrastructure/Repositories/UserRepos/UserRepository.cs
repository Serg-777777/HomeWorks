
using Domain.Models;
using Domain.Models.UserModels;

namespace Infrastructure.Repositories.UserRepos;

sealed public class UserRepository : IUserRepository
{
    ICollection<UserModel> _users;
    IRepositoryCRUD<UserProfileModel> _profilesRepos;
    IRepositoryCRUD<UserSettingModel> _settingsRepos;

    public IReadOnlyCollection<UserModel> Entities => _users.ToList() ;

    public UserRepository(ICollection<UserModel> users, IRepositoryCRUD<UserProfileModel> profilesRepos, IRepositoryCRUD<UserSettingModel> settingsRepos)
    {
        _users = users;
        _profilesRepos = profilesRepos;
        _settingsRepos = settingsRepos;
    }

    // для вывода нестандартных отчётов
    public object GetReport(IEntityVisitor<UserModel> entityVisitor)
    {
        return entityVisitor.Excute(this);
    }

    public bool AddEntity(UserModel entity)
    {
        throw new NotImplementedException();
    }

    public UserModel? GetEntity(int id)
    {
        throw new NotImplementedException();
    }
    public UserModel? GetEntity(string login)
    {
        throw new NotImplementedException();
    }
    public UserProfileModel? GetProfileUserByLogin(string login)
    {
        throw new NotImplementedException();
    }
    public bool RemoveEntity(int entityID)
    {
        throw new NotImplementedException();
    }
    public bool RemoveEntity(string login)
    {
        throw new NotImplementedException();
    }
    public UserModel UpdateEntity(UserModel entity)
    {
        throw new NotImplementedException();
    }
    public UserSettingModel? GetSettingUserByLogin(string login)
    {
        throw new NotImplementedException();
    }
}



using AutoMapper;
using Domain.Models.UserModels;
using Infrastructure.DtoLogics.UserDtoLogics;
using Infrastructure.Repositories.UserRepos;
using Microsoft.Extensions.Logging;

namespace Application.ServicesApps.UserServicesApps;

public class UserMapperService
{
    UserRepository _userRepository;
    IMapper _mapper;
    ILogger<UserMapperService> _logger;
    public UserMapperService(UserRepository userRepository, IMapper mapper, ILogger<UserMapperService> logger)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public IReadOnlyCollection<UserDtoLogic> GetUsers()
    {
        var users = _userRepository.Entities.AsQueryable();
        var usersLogics = _mapper.Map<IReadOnlyCollection<UserDtoLogic>>(users);
        return usersLogics;
    }
    public UserDtoLogic GetUser(string login)
    {
        var user = _userRepository.GetEntity(login);
        var userLogic = _mapper.Map<UserDtoLogic>(user);
        return userLogic;
    }
    public UserProfileDtoLogic? GetProfile(string login)
    {
        var prof = _userRepository?.GetProfile(login);
        var profLogic = _mapper.Map<UserProfileDtoLogic>(prof);
        return profLogic;

        //var userProfile = _userRepository?.GetEntity(login)?.UserProfile;
        //return userProfile;
    }
    public UserSettingDtoLogic GetSetting(string login)
    {
        var sett = _userRepository.GetSetting(login);
        var settLogic = _mapper.Map<UserSettingDtoLogic>(sett);
        return settLogic;
    }

    public bool CreateUser(UserDtoLogic userDtoLogic, UserProfileDtoLogic userProfileLogic)
    {
        var user = _mapper.Map<UserModel>(userDtoLogic);
        var role = new UserRoleModel() { RoleUser = "пользователь" };

        var profile = _mapper.Map<UserProfileModel>(userProfileLogic);
        var setting = _mapper.Map<UserSettingModel>(new UserSettingDtoLogic());

        user
            .CreateProfile(profile)
            .CreateRole(role)
            .SetDateCreated(DateTime.Now);
        _userRepository.AddEntity(user);

        return true;
    }

    public bool UpdateUser(string login, UserDtoLogic userDtoLogic)
    {
        var user = _mapper.Map<UserModel>(userDtoLogic);
        _userRepository.UpdateEntity(login, user);
        return true;
    }
    public bool UpdateProfile(string login, UserProfileDtoLogic userProfileLogic)
    {
        var newProfile = _mapper.Map<UserProfileModel>(userProfileLogic);
        var user = _userRepository.GetEntity(login);
        _userRepository.UpdateProfile(user!.Login, newProfile);

        return true;
    }
    public bool UpdateSetting(string login, UserSettingDtoLogic settingDtoLogic)
    {
        var newSett = _mapper.Map<UserSettingModel>(settingDtoLogic);
        _userRepository.UpdateSetting(login, newSett);

        return true;
    }

    public bool DeleteUser(UserDtoLogic userDtoLogic)
    {
        var res = _userRepository.RemoveEntity(userDtoLogic?.Login!);
        return res;
    }

}

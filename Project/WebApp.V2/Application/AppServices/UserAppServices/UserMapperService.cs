

using AutoMapper;
using Domain.Models.UserModels;
using Infrastructure.DtoLogics.UserDtoLogics;
using Infrastructure.Repositories.UserRepos;
using Microsoft.Extensions.Logging;

namespace Application.ServicesApps.UserServicesApps;

public class UserMapperService
{
    IUserRepository _userRepository;
    IMapper _mapper;
    ILogger<UserMapperService> _logger;
    public UserMapperService(IUserRepository userRepository, IMapper mapper, ILogger<UserMapperService> logger)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public ICollection<UserDtoLogic> GetUsers()
    {
        var users = _userRepository.Entities;
        var usersLogics = _mapper.Map<ICollection<UserDtoLogic>>(users);
        return usersLogics;
    }
    public bool CreateUser(UserDtoLogic userDtoLogic, UserProfileDtoLogic userProfileLogic)
    {
        var user = _mapper.Map<UserModel>(userDtoLogic);
        var role = new UserRoleModel() { RoleUser = "пользователь" };
        var profile = _mapper.Map<UserProfileModel>(userProfileLogic); 
        var setting = _mapper.Map<UserSettingModel>(new UserSettingDtoLogic()); 

        user?
            .SetProfile(profile)
            .SetSettings(setting!)
            .SetRole(role)
            .SetDateCreated(DateTime.Now);

        _logger.LogInformation($":::TEST MAPPER ADD::: Login:{user?.Login}, Name:{profile.FirstName} Date: {setting?.UserModel?.DateCreated}");

        _userRepository.AddEntity(user!);
        return true;
    }

    public UserDtoLogic GetUser(int userId)
    {
        var user = _userRepository.GetEntity(userId);
        var userLogic = _mapper.Map<UserDtoLogic>(user);
        return userLogic;
    }
    public UserProfileDtoLogic? GetProfile(int userId)
    {
        var prof = _userRepository?.GetProfile(userId);
        var profLogic = _mapper.Map<UserProfileDtoLogic>(prof);
        return profLogic;

    }
    public UserSettingDtoLogic GetSetting(int userId)
    {
        var sett = _userRepository.GetSetting(userId);
        var settLogic = _mapper.Map<UserSettingDtoLogic>(sett);
        return settLogic;
    }
    public UserProfileDtoLogic GetProfile(string loginUser)
    {
        var profile = _userRepository.GetProfile(loginUser);
        var profileLogic = _mapper.Map<UserProfileDtoLogic>(profile);
        return profileLogic;
    }
    public bool UpdateUser(int userId, UserDtoLogic userDtoLogic)
    {
        var user = _mapper.Map<UserModel>(userDtoLogic);
        _userRepository.UpdateEntity(userId, user);
        return true;
    }
    public bool UpdateProfile(int userId, UserProfileDtoLogic userProfileLogic)
    {
        var newProfile = _mapper.Map<UserProfileModel>(userProfileLogic);
        var user = _userRepository.GetEntity(userId);
        _userRepository.UpdateProfile(user!.Id, newProfile);

        return true;
    }
    public bool UpdateSetting(int userId, UserSettingDtoLogic settingDtoLogic)
    {
        var newSett = _mapper.Map<UserSettingModel>(settingDtoLogic);
        _userRepository.UpdateSetting(userId, newSett);

        return true;
    }
    public bool DeleteUser(int userId)
    {
        var res = _userRepository.RemoveEntity(userId);
        return res;
    }

}

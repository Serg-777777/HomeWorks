
using AutoMapper;
using Domain.Models.UserModels;
using Infrastructure.DtoLogics.UserDtoLogics;
using Infrastructure.Repositories.UserRepos;
using Microsoft.Extensions.Logging;

namespace Application.ServicesApps.UserServicesApps;

public class UserAdapterService
{
    UserRepository _userRepository;
    IMapper _mapper;
    ILogger<UserAdapterService> _logger;
    public UserAdapterService(UserRepository userRepository, IMapper mapper, ILogger<UserAdapterService> logger)
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
    public bool CreateUser(UserDtoLogic userDtoLogic)
    {
        var userModel = _mapper.Map<UserModel>(userDtoLogic);
        userModel
            .SetDateCreated(DateTime.Now)
            .CreateRole(new UserRoleModel() { RoleUser = "пользователь" });
        var res = _userRepository.AddEntity(userModel);
        return res;
    }
    public bool CreateUser(UserDtoLogic userDtoLogic, UserDtoLogic userProfileLogic, UserSettingDtoLogic userSettingLogic)
    {
        var user = _mapper.Map<UserModel>(userDtoLogic);
        var profile = _mapper.Map<UserProfileModel>(userDtoLogic);
        var setting = _mapper.Map<UserSettingModel>(userDtoLogic);
        var role = new UserRoleModel() { RoleUser = "польхователь" };

        user
            .CreateProfile(profile)
            .CreateSettings(setting)
            .CreateRole(role)
            .SetDateCreated(DateTime.Now);
        _userRepository.AddEntity(user);

        return true;
    }
    public bool UpdateProfile(string login, UserProfileDtoLogic userProfileLogic)
    {
        var newProfile = _mapper.Map<UserProfileModel>(userProfileLogic);
        var user = _userRepository.GetEntity(login);
        _userRepository.UpdateProfile(user!.Id, newProfile);

        return true;
    }
    public UserProfileDtoLogic?  GetProfile(string login)
    {
        var userId = (int)_userRepository?.GetEntity(login)?.Id!;
        var prof = _userRepository?.GetProfile(userId!);
        var profLogic = _mapper.Map<UserProfileDtoLogic>(prof);
        return profLogic;

        //var userProfile = _userRepository?.GetEntity(login)?.UserProfile;
        //return userProfile;
    }
}



using Application.DtoLogics.UserDtoLogics;
using AutoMapper;
using Domain.Models.UserModels;
using Infrastructure.DtoLogics.UserDtoLogics;
using Infrastructure.Repositories.UserRepos;

namespace Application.ServicesViews.UserServicesApps;

public class UserService
{
    IUserRepository _userRepository;
    IMapper _mapper;
    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserFullDtoLogic>? AuthorizeAsync(string login, string password)
    {
        var user = await _userRepository.AuthorizeAsync(login, password)!;
        if (user != default!)
        {
            var uLogic = _mapper.Map<UserFullDtoLogic>(user);
            return uLogic;
        }
        return null!;
    }
    public async Task<UserFullDtoLogic>? InfoAsync(int id)
    {
        var user = await _userRepository.GetEntityAsync(id)!;
        if (user != default!)
        {
            var uLogic = _mapper.Map<UserFullDtoLogic>(user);
            return uLogic;
        }
        return null!;
    }
    public async Task<List<UserFullDtoLogic>> GetUsersAsync()
    {
        var users = await _userRepository.EntitiesAsync();
        var usersLogics = _mapper.Map<List<UserFullDtoLogic>>(users);
        return usersLogics;
    }

    public async Task<UserFullDtoLogic>? CreateUserAsync(UserDtoLogic userDtoLogic)
    {
        var userModel = _mapper.Map<UserModel>(userDtoLogic);
        var role = new UserRoleModel() { RoleName = "гость" };
        var prof = new UserProfileModel();
        userModel
            .SetDateCreated(DateTime.Now)
            .SetRole(role)
            .SetProfile(prof);
        prof.SetUserProperty(userModel);
        var newUser = await _userRepository.AddEntityAsync(userModel)!;
        if (newUser != default!)
        {
            var newUserLogic = _mapper.Map<UserFullDtoLogic>(newUser);
            return newUserLogic!;
        }
        return null!;
    }

    public async Task<UserFullDtoLogic>? GetUserAsync(int userId)
    {
        var user = await _userRepository.GetEntityAsync(userId)!;
        if (user != default!)
        {
            var userIdLogic = _mapper.Map<UserFullDtoLogic>(user);
            return userIdLogic;
        }
        return null!;
    }

    public async Task<UserFullDtoLogic>? UpdateUserAsync(UserFullDtoLogic newUser)
    {
        var userModel = _mapper.Map<UserModel>(newUser);
        var u = await _userRepository.UpdateEntityAsync(newUser.Id, userModel)!;
        var userLogic = _mapper.Map<UserFullDtoLogic>(u);
        return userLogic;
    }
    public async Task<bool> DeleteUserAsync(int id)
    {
        var res = await _userRepository.RemoveEntityAsync(id);
        return res;
    }

    public async Task<bool> EraseUserAsync(int idUser)
    {
        var res = await _userRepository.EraseEntityAsync(idUser);
        return res;
    }
}




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
    
    public UserFullDtoLogic? Authorize(string login, string password)
    {
        var user = _userRepository.Authorize(login, password);
        if(user != null)
        {
            var uLogic = _mapper.Map<UserFullDtoLogic>(user);
            return uLogic;
        }
        return null;
    }
    public UserFullDtoLogic? Info(int id)
    {
        var user = _userRepository.GetEntity(id);
        var uLogic = _mapper.Map<UserFullDtoLogic>(user);
        return uLogic;
    }
    public List<UserFullDtoLogic> GetUsers()
    {
        var users = _userRepository.Entities;
        var usersLogics = _mapper.Map<List<UserFullDtoLogic>>(users);
        return usersLogics;
    }
    
    public UserFullDtoLogic? CreateUser(UserDtoLogic userDtoLogic)
    {
        var userModel = _mapper.Map<UserModel>(userDtoLogic);
        var role = new UserRoleModel() { RoleName = "гость" };
        var prof = new UserProfileModel();
        userModel
            .SetDateCreated(DateTime.Now)
            .SetRole(role)
            .SetProfile(prof);
        prof.SetUserProperty(userModel);
        var newUser = _userRepository.AddEntity(userModel);
        if (newUser != null)
        {
            var newUserLogic = _mapper.Map<UserFullDtoLogic>(newUser);
            return newUserLogic!;
        }
        return null;
    }

    public UserFullDtoLogic? GetUser(int userId)
    {
        var user = _userRepository.GetEntity(userId);
        if (user != null)
        {
            var userIdLogic = _mapper.Map<UserFullDtoLogic>(user);
            return userIdLogic;
        }
        return null;
    }

    public UserFullDtoLogic? UpdateUser(UserFullDtoLogic newUser)
    {
            var userModel = _mapper.Map<UserModel>(newUser);
            var u = _userRepository.UpdateEntity(newUser.Id, userModel);
            var userLogic = _mapper.Map<UserFullDtoLogic> (u);
            return userLogic;
    }
    public bool DeleteUser(int id)
    {
        var res = _userRepository.RemoveEntity(id);
        return res;
    }
    
    public bool UpdateUsers(List<UserFullDtoLogic> userFullDtos)
    {
        var us = _mapper.Map<List<UserModel>>(userFullDtos);
        var res = _userRepository.UpdateEntityRange(us);
        return res;
    }

    public bool EraseUser(int idUser)
    {
        var res = _userRepository.EraseEntity(idUser);
        return res;
    }
}


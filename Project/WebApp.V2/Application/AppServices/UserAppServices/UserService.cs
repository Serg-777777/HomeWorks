

using Application.DtoLogics.UserDtoLogics;
using AutoMapper;
using Domain.Models.UserModels;
using Infrastructure.DtoLogics.UserDtoLogics;
using Infrastructure.Repositories.UserRepos;
using Microsoft.Extensions.Logging;

namespace Application.ServicesViews.UserServicesApps;

public class UserService
{
    IUserRepository _userRepository;
    IMapper _mapper;
    ILogger<UserService> _logger;
    public UserService(IUserRepository userRepository, IMapper mapper, ILogger<UserService> logger)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _logger = logger;
    }
    public UserFullDtoLogic? Authorize(string login, string password)
    {
        var u = _userRepository.Authorize(login, password);
        if(u != null)
        {
            var uLogic = _mapper.Map<UserFullDtoLogic>(u);
            return uLogic;
        }
        return null;
    }
    public List<UserFullDtoLogic> GetUsers()
    {
        var users = _userRepository.Entities;
        var usersLogics = _mapper.Map<List<UserFullDtoLogic>>(users);
        _logger.LogInformation($":::TEST ALL count: {usersLogics.Count}");
        return usersLogics;
    }
    public UserFullDtoLogic? CreateUser(UserDtoLogic userDtoLogic)
    {
        var userModel = _mapper.Map<UserModel>(userDtoLogic).SetDateCreated(DateTime.Now);
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

    public UserFullDtoLogic? UpdateUser(int idUser, UserFullDtoLogic newUser)
    {

            var userModel = _mapper.Map<UserModel>(newUser);
            var u = _userRepository.UpdateEntity(idUser, userModel);
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


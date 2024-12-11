

using Application.DtoLogics.UserDtoLogics;
using AutoMapper;
using Domain.Models;
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

    public UserDtoLogic? GetUser(int userId)
    {
        var user = _userRepository.GetEntity(userId);
        if (user != null)
        {
            var userIdLogic = _mapper.Map<UserDtoLogic>(user);
            return userIdLogic;
        }
        return null;
    }

    public UserDtoLogic UpdateUser(int idUser, UserDtoLogic newUser)
    {
        var userModel = _mapper.Map<UserModel>(newUser);
        var user = _userRepository.UpdateEntity(idUser, userModel);
        if (user != null)
        {
            var userLogic = _mapper.Map<UserDtoLogic>(user);
            return userLogic;
        }
        return null!;
    }
    public bool DeleteUser(int id)
    {
        var res = _userRepository.RemoveEntity(id);
        return res;
    }
    
    public bool UpdateUsers(IEnumerable<UserFullDtoLogic> userFullDtos)
    {
        var us = _mapper.Map<IEnumerable<UserModel>>(userFullDtos);
        var res = _userRepository.UpdateEntityRange(us);
        return res;
    }

    public bool EraseUser(int idUser)
    {
        var res = _userRepository.EraseEntity(idUser);
        return res;
    }
}


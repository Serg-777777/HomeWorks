

using Application.DtoLogics.UserDtoLogics;
using AutoMapper;
using Domain.Models;
using Domain.Models.UserModels;
using Infrastructure.DtoLogics.UserDtoLogics;
using Infrastructure.Repositories.UserRepos;
using Microsoft.Extensions.Logging;

namespace Application.ServicesApps.UserServicesApps;

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

    public IReadOnlyCollection<UserDtoLogic> GetUsers()
    {
        var users = _userRepository.Entities;
        var usersLogics = _mapper.Map<IReadOnlyCollection<UserDtoLogic>>(users);
        _logger.LogInformation($":::TEST ALL count: {usersLogics.Count}");
        return usersLogics;
    }
    public UserIdDtoLogic? CreateUser(UserDtoLogic userDtoLogic)
    {
        var userModel = _mapper.Map<UserModel>(userDtoLogic).SetDateCreated(DateTime.Now);
        var newUser = _userRepository.AddEntity(userModel);
        if (newUser != null)
        {
            var newUserLogic = _mapper.Map<UserIdDtoLogic>(newUser);
            return newUserLogic!;
        }
        return null;
    }

    public UserIdDtoLogic? GetUser(int userId)
    {
        var user = _userRepository.GetEntity(userId);
        if (user != null)
        {
            var userIdLogic = _mapper.Map<UserIdDtoLogic>(user);
            return userIdLogic;
        }
        return null;
    }

    public UserIdDtoLogic UpdateUser(int idUser, UserDtoLogic newUser)
    {
        var userModel = _mapper.Map<UserModel>(newUser);
        var user = _userRepository.UpdateEntity(idUser, userModel);
        if (user != null)
        {
            var userLogic = _mapper.Map<UserIdDtoLogic>(user);
            return userLogic;
        }
        return null!;
    }
    public bool DeleteUser(int id)
    {
        var res = _userRepository.RemoveEntity(id);
        return res;
    }
}


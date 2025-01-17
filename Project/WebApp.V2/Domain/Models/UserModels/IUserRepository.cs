﻿
using Domain.Models;
using Domain.Models.UserModels;

namespace Infrastructure.Repositories.UserRepos;

public interface IUserRepository : IRepository<UserModel, int>
{
    public bool UpdateEntityRange(List<UserModel> userModels);
    public bool EraseEntity(int idUser);
    public UserModel? Authorize(string login, string password);
}

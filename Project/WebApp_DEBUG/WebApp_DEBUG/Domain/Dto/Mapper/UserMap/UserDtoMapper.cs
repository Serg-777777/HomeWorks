﻿
using WebApp_DEBUG.Domain.Model.UserModel;

namespace WebApp_DEBUG.Domain.Dto.Mapper.UserDtoMapper;

public class UserModelDto : IDto
{
    public string Login { get; set; } = String.Empty;
    public string Password { get; set; } = String.Empty;
    public string? Email { get; set; }
}
public class UserCurrentDto: IDto
{
    public int Id { get; set; }
    public string Login { get; set; } = String.Empty;
    public required UserRole UserRole { set; get; }
}

public class UserInfoDto: IDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int? Age { get; set; }
    public string? Country { get; set; }
    public string? City { get; set; }
}


﻿

namespace Domain.Models.UserModels;

public class UserModel : IEntity
{

    public int Id { get; set; }
    public DateTime DateCreated { get; private set; }
    public bool IsDeleted { get; private set; } = false;
    public string? Login { get; private set; }
    public string? Password { get; private set; }
    public string? Email { get; private set; }
    public UserRoleModel? Role { get; private set; }
    public UserProfileModel? Profile { get; set; }

    protected UserModel() { }
    public UserModel(string login, string password, string email, DateTime dateTime, UserRoleModel role)
    {
        Login = login ?? throw new ArgumentNullException(nameof(login));
        Password = password ?? throw new ArgumentNullException(nameof(password));
        Email = email ?? throw new ArgumentNullException(nameof(email));
        DateCreated = dateTime;
        Role = role;
    }
    public UserModel SetProfile(UserProfileModel userProfileModel)
    {
        Profile = userProfileModel;
        return this;
    }
    public UserModel SetEditValues(UserModel entity)
    {
        // Login = entity.Login; проверка на уникальность
        if (!String.IsNullOrEmpty(Email)) Email = entity.Email;
        if (!String.IsNullOrEmpty(Password)) Password = entity.Password;
        if (entity.Role != null) Role = entity.Role;

        return this;
    }
    public UserModel SetRole(UserRoleModel userRole)
    {
        Role = userRole;
        return this;
    }
    public UserModel SetDateCreated(DateTime dateTime)
    {
        this.DateCreated = dateTime;
        return this;
    }
    public UserModel SetIsDelete(bool val)
    {
        this.IsDeleted = val;
        return this;
    }
    public bool Equals(UserModel? other)
    {
        return (this.Id == other?.Id);
    }

}
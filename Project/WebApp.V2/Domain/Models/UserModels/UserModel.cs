

namespace Domain.Models.UserModels;

 public class UserModel : IEntity
{
    public const string TableName = "Users";

    public int Id { get; set; }
    public DateTime DateCreated { get; private set; }
    public bool IsDeleted { get; private set; } = false;
    public string? Login { get; private set; }
    public string? Password { get; private set; }
    public string? Email { get; private set; }

    public UserProfileModel? UserProfile { get;  set; }
    public UserSettingModel? UserSetting { get; set; } 
    public UserRoleModel? UserRole { get; set; }

    protected UserModel() { }
    public UserModel(string login, string password, string email)
    {
        Login = login ?? throw new ArgumentNullException(nameof(login));
        Password = password ?? throw new ArgumentNullException(nameof(password));
        Email = email ?? throw new ArgumentNullException(nameof(email));
        this.SetDateCreated(DateTime.Now);
    }

   public UserModel SetLogin(string login)
    {
        this.Login = login;
        return this;
    }
    public UserModel SetPassword(string password)
    {
        this.Password = password;
        return this;
    }
    public UserModel SetEmail(string mail)
    {
        this.Email = mail;
        return this;
    }
    public bool Equals(UserModel? other)
    {
        return (this.Id == other?.Id || this.Login == other?.Login);
    }
    public UserModel SetDelete(bool val)
    {
        this.IsDeleted = val;
        return this;
    }
    public UserModel SetDateCreated(DateTime dateTime)
    {
        this.DateCreated = dateTime;
        return this;
    }
    public UserModel SetSettings(UserSettingModel userSetting)
    {
        this.UserSetting = userSetting;
        return this;
    }
    public UserModel SetProfile(UserProfileModel userProfile)
    {
        this.UserProfile = userProfile;
        return this;
    }
    public UserModel SetRole(UserRoleModel roleModel)
    {
        this.UserRole = roleModel;
        return this;
    }

}
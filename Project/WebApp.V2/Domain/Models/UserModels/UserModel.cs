

namespace Domain.Models.UserModels;

 sealed public class UserModel: IEntity
{
    public const string TableName= "Users";

        public int Id { get; private set; }
        public DateTime DateCreated { get; private set; }
        public bool IsDeleted { get; private set; } = false;
        public string Login { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }

    public UserProfileModel? UserProfile { get; private set; } = null;
    public UserSettingModel? UserSetting { get; private set; } = null;
    public UserRoleModel UserRole { get; private set; }

    public UserModel(int id, string login, string password, string email, UserRoleModel userRole)
    {
        Login = login ?? throw new ArgumentNullException(nameof(login));
        Password = password ?? throw new ArgumentNullException(nameof(password));
        Email = email ?? throw new ArgumentNullException(nameof(email));
        UserRole = userRole ?? throw new ArgumentNullException(nameof(userRole));
        Id = id;
        this.SetDateCreated(DateTime.Now);
    }

    public bool Equals(UserModel? other)
    {
        return (this.Id == other?.Id || this.Login == other?.Login);
    }

    public UserModel SetDateCreated(DateTime dateTime)
    {
        this.DateCreated = dateTime;
        return this;
    }

    public UserModel CreateSettings(UserSettingModel userSetting)
    {
        this.UserSetting = userSetting;
        return this;
    }
    public UserModel CreateProfile(UserProfileModel userProfile)
    {
        this.UserProfile = userProfile;
        return this;
    }
    public UserModel CreateRole(UserRoleModel roleModel)
    {
        this.UserRole = roleModel;
        return this;
    }

}
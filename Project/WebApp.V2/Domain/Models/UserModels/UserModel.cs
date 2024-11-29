

namespace Domain.Models.UserModels;

 sealed public class UserModel: IEntity
{
    public const string EntityName= "UserModel";

        public int Id { get; private set; }
        public bool IsDeleted { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }

        public UserProfileModel UserProfile { get; private set; }
        public UserSettingModel UserSetting { get; private set; }
        public UserRoleModel UserRole { get; private set; }

    public UserModel(bool isDeleted, string login, string password, string email, UserProfileModel userProfile, UserSettingModel userSetting, UserRoleModel userRole)
    {
        IsDeleted = isDeleted;
        Login = login ?? throw new ArgumentNullException(nameof(login));
        Password = password ?? throw new ArgumentNullException(nameof(password));
        Email = email ?? throw new ArgumentNullException(nameof(email));
        UserProfile = userProfile ?? throw new ArgumentNullException(nameof(userProfile));
        UserSetting = userSetting ?? throw new ArgumentNullException(nameof(userSetting));
        UserRole = userRole ?? throw new ArgumentNullException(nameof(userRole));
    }

    public bool Equals(UserModel? other)
    {
        return (this.Id == other?.Id || this.Login == other?.Login);
    }

}

namespace Domain.Models.UserModels;

 sealed public partial class UserModel:EntityBase<UserModel>, IEntity
{
    public const string EntityName= "UserModel";

    public int Id { private set; get; }
    public bool isDeleted { private set; get; } 
    public string Login { private set; get; }
    public string Password { private set; get; }
    public string Email { private set; get; } 

    public UserProfileModel UserProfile { private set; get; } 
    public UserSettingModel UserSetting { private set; get; } 
    public UserRoleModel UserRole { private set; get; } 

    public UserModel(string login)
    {
      var u =  base._entities.Value.FirstOrDefault(u => u.Login == login);
        if (u is null)
            throw new ArgumentNullException(login, "Пользователь не найден");
        Id = u!.Id;
        isDeleted = u.isDeleted;
        Login = u.Login;
        Password = u.Password;
        Email = u.Email;
        UserProfile = u.UserProfile;
        UserSetting = u.UserSetting;
        UserRole = u.UserRole;

    }
    public UserModel(int id, bool IsDeleted, string login, string password, string email, 
        UserProfileModel userProfile, UserSettingModel userSetting, UserRoleModel userRole)
    {
        Id = id;
        isDeleted = IsDeleted;
        Login = login ?? throw new ArgumentNullException(nameof(login));
        Password = password ?? throw new ArgumentNullException(nameof(password));
        Email = email ?? throw new ArgumentNullException(nameof(email));
        UserProfile = userProfile ?? throw new ArgumentNullException(nameof(userProfile));
        UserSetting = userSetting ?? throw new ArgumentNullException(nameof(userSetting));
        UserRole = userRole ?? throw new ArgumentNullException(nameof(userRole));
    }

    public bool AddUser()
    {
        if(!base.Entities().Contains(this))
        {
            var u = base.AddEntity(this);
            u.UserProfile?.AddProfile();
            u.UserSetting?.AddSettings();
            return true;
        }
        return false;
    }
    public bool RemoveUser()
    {

        if(base.RemoveEntity(this))
        {
            this.UserProfile?.RemoveProfile();
            this.UserSetting?.RemoveSettings();
            return true;
        }
        return false;
    }

    public override bool Equals(UserModel? other)
    {
        return (this.Id == other?.Id || this.Login == other?.Login);
    }
}
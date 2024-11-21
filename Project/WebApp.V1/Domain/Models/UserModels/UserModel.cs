

namespace Domain.Models.UserModel
{
    public class UserModel:IEntity
    {
        public const string EntityName= "UserModel";

        public int Id { set; get; }
        public bool isDeleted { set; get; } = false;
        public required string Login { set; get; }
        public required string Password { set; get; }
        public required string Email { set; get; } 

        public required UserProfileModel UserProfile { set; get; }
        public required UserSettingModel UserSetting { set; get; }
        public required UserRoleModel UserRole { set; get; }
       
    }
}
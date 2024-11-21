

namespace Domain.Models.UserModel
{
    public class UserProfileModel:IEntity
    {
        public const string EntityName = "UserProfileModel";

        public int Id { set; get; }
        public string? FirstName { set; get; }
        public string? LastName { set; get; }
        public string? Country { set; get; }
        public string? City { set; get; }
        public int? Age { set; get; }

        public required int UserModelId { set; get; }

    }
}


namespace Domain.Models.UserModels;

    sealed public class UserProfileModel: IEntity
    {
        public const string EntityName = "UserProfileModel";

        public int? Id { get; private set; }
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public string? Country { get; private set; }
        public string? City { get; private set; }
        public int? Age { get; private set; }
        public int? UserModelId { get; private set; }

    public UserProfileModel(string? firstName, string? lastName, string? country, string? city, int? age, int userModelId)
     {
        FirstName = firstName;
        LastName = lastName;
        Country = country;
        City = city;
        Age = age;
        UserModelId = userModelId;
     }
        public bool Equals(UserProfileModel? other)
        {
            return this.Id == other?.Id;
        }
    }


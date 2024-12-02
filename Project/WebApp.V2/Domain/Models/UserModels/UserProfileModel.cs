
namespace Domain.Models.UserModels;

    sealed public class UserProfileModel: IEntity
    {
        public const string TableName = "UserProfiles";

        public int Id { get; private set; }
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public string? Country { get; private set; }
        public string? City { get; private set; }
        public int? Age { get; private set; }
        public int UserModelId { get; private set; }

    public UserProfileModel(int id, string? firstName, string? lastName, string? country, string? city, int? age, int userModelId)
    {
        FirstName = firstName;
        LastName = lastName;
        Country = country;
        City = city;
        Age = age;
        UserModelId = userModelId;
        Id = id;
    }
    public UserProfileModel SetValues(UserProfileModel userProfile)
    {
        FirstName = userProfile.FirstName;
        LastName = userProfile.LastName;
        Country = userProfile.Country;
        City = userProfile.City;
        Age = userProfile.Age;

        return this;
    }
    public bool Equals(UserProfileModel? other)
        {
            return this.Id == other?.Id;
        }
    }


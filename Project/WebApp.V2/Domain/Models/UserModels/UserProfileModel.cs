
namespace Domain.Models.UserModels;

    sealed public partial class UserProfileModel:EntityBase<UserProfileModel>, IEntity
    {
        public const string EntityName = "UserProfileModel";

        public UserProfileModel(int id, string? firstName, string? lastName, string? country, string? city, int? age, int userModelId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Country = country;
            City = city;
            Age = age;
            UserModelId = userModelId;
        }

        public int Id { private set; get; }
        public string? FirstName { private set; get; }
        public string? LastName { private set; get; }
        public string? Country { private set; get; }
        public string? City { private set; get; }
        public int? Age { private set; get; }

        public int UserModelId {private set; get; }

        public UserProfileModel? AddProfile()
        {
            return base.AddEntity(this);
        }
        public bool RemoveProfile()
        {
            return base.RemoveEntity(this);
        }

        public override bool Equals(UserProfileModel? other)
        {
            return this.Id == other?.Id;
        }
    }


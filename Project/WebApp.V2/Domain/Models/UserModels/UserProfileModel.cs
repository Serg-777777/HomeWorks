
namespace Domain.Models.UserModels;

    sealed public partial class UserProfileModel:EntityBase<UserProfileModel>, IEntity
    {
        public const string EntityName = "UserProfileModel";

        public int? Id { private set; get; }
        public string? FirstName { private set; get; }
        public string? LastName { private set; get; }
        public string? Country { private set; get; }
        public string? City { private set; get; }
        public int? Age { private set; get; }
        public int? UserModelId { private set; get; }

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
        public UserProfileModel()
        {
            this.Id = null;
            this.UserModelId = null;
        }

     
       public bool UpdateValues(int idUser, string? firstName, string? lastName, string? country, string? city, int? age)
        {
           var profile = base._entities.Value.FirstOrDefault(p => p.UserModelId == idUser);
            if(profile != null)
           {
                profile.FirstName = firstName;
                profile.LastName = lastName;
                profile.Country = country;
                profile.City = city;
                profile.Age = age;
                return true;
            }
            return false;
         }

        public UserProfileModel? AddProfile()
        {
             if (this.Id == null) return null;
             return base.AddEntity(this);
        }
        public bool RemoveProfile()
        {
            if (this.Id == null) return false;
            return base.RemoveEntity(this);
        }

        public override bool Equals(UserProfileModel? other)
        {
            return this.Id == other?.Id;
        }
    }


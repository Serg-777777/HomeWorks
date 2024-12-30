
namespace Domain.Models.UserModels;

 public class UserProfileModel : IEntity
{

    public int Id { get; set; }
    public string? FirstName { get; private set; } = "";
    public string? LastName { get; private set; } = "";
    public string? Country { get; private set; } = "";
    public string? City { get; private set; } = "";
    public int? Age { get; private set; } = null;
    public int UserId { set; get; }
    public UserModel? User { get; set; }

    public UserProfileModel() { }

    public UserProfileModel(string? firstName, string? lastName, string? country, string? city, int? age)
    {
        FirstName = firstName;
        LastName = lastName;
        Country = country;
        City = city;
        Age = age;
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
    public UserProfileModel SetUserProperty(UserModel user)
    {
        User = user;
        return this;
    }
    public bool Equals(UserProfileModel? other)
    {
        return this.Id == other?.Id;
    }
}


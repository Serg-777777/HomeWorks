
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
    public override bool Equals(object? other)
    {
        if ((other is UserProfileModel obj) && (obj != null))
            return this.UserId == obj.UserId;
        return false;
    }

    public int Compare(object? x, object? y)
    {
        if ((x is UserProfileModel x1 && y is UserProfileModel y1) && (x1 != null! && y1 != null!))
            return x1.UserId - y1.UserId;
        return -1000;
    }

    public override int GetHashCode()
    {
        return this.Id.GetHashCode();
    }
}


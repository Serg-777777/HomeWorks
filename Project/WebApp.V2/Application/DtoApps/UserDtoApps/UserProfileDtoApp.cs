

namespace Application.DtoApps.UserDtoApps;

public class UserProfileDtoApp:IUserDtoApp
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Country { get; set; }
    public string? City { get; set; }
    public int? Age { get; set; }
}

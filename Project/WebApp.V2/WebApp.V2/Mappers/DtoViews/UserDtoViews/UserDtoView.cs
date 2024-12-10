namespace Presentation.Mappers.DtoApps.UserDtoViews;

public class UserDtoView : IUserDtoView
{
    public string? Login { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
}

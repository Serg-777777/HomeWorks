namespace Presentation.Mappers.DtoViews.UserDtoViews;

public class UserDtoView : IUserDtoView
{
    public string? Login { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
}

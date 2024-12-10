using Presentation.Mappers.DtoApps.UserDtoViews;

namespace Presentation.Mappers.DtoViews.UserDtoViews;

public class UserIdDtoView:IUserDtoView
{
    public int Id { get; private set; }
    public string? Login { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public UserIdDtoView(int id)
    {
        Id= id;
    }
}

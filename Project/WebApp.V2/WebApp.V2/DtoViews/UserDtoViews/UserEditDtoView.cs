namespace Presentation.DtoViews.UserDtoViews;

public class UserEditDtoView
{
    public int Id { get; set; }
    public string? Login { get; set; }
    public string? Email { get; set; }
    public RoleDtoView? Role { get; set; }
}

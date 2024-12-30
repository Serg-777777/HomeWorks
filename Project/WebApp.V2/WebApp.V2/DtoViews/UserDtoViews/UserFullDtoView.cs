namespace Presentation.DtoViews.UserDtoViews;

public class UserFullDtoView : IUserDtoView
{
    public bool IsDeleted { get; set; }
    public int Id { get; set; }
    public string? Login { get; set; }
    public DateTime DateCreated { get; set; }
    public string? Email { get; set; }
    public RoleDtoView? Role { get; set; }
}


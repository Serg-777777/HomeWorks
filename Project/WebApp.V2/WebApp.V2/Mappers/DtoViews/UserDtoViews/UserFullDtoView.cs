namespace Presentation.Mappers.DtoViews.UserDtoViews;

public class UserFullDtoView:IUserDtoView
{
    public int Id { get; set; }
    public DateTime DateCreated { get; set; }
    public bool IsDeleted { get; set; }
    public string? Login { get; set; }
    public string? Email { get; set; }
}


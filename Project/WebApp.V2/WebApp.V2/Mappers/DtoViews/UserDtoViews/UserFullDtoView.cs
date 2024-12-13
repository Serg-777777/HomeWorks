
namespace Presentation.Mappers.DtoViews.UserDtoViews;

//[BindProperties(SupportsGet =true)]
public class UserFullDtoView:IUserDtoView
{
    public UserFullDtoView() { }
    public bool IsDeleted { get; set; }
    public int Id { get; set; }
    public string? Login { get; set; }
    public DateTime DateCreated { get; set; }
    public string? Email { get; set; }

}


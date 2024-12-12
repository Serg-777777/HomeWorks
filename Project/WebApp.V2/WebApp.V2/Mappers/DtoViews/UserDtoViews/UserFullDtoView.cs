using Microsoft.AspNetCore.Mvc;

namespace Presentation.Mappers.DtoViews.UserDtoViews;

[BindProperties(SupportsGet =true)]
public class UserFullDtoView:IUserDtoView
{
    public UserFullDtoView() { }
    public int Id { get; set; }
    public DateTime DateCreated { get; set; }
    public bool IsDeleted { get; set; }
    public string? Login { get; set; }
    public string? Email { get; set; }
}


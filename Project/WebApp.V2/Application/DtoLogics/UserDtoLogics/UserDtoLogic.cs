namespace Infrastructure.DtoLogics.UserDtoLogics;

public class UserDtoLogic:IUserDtoLogic
{
    public DateTime DateCreated { get; set; }
    public bool IsDeleted { get; set; }
    public string? Login { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }  
}

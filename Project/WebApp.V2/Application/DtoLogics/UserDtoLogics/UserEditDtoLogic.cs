

namespace Application.DtoLogics.UserDtoLogics;

public class UserEditDtoLogic
{
    public int Id { get; set; }
    public string? Login { get; set; }
    public string? Email { get; set; }
    public RoleDtoLogic? Role { get; set; }
}

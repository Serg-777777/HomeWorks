
using Infrastructure.DtoLogics.UserDtoLogics;

namespace Application.DtoLogics.UserDtoLogics;

public class UserFullDtoLogic
{
    public int Id { get; set; }
    public string? Login { get; set; }
    public DateTime DateCreated { get; set; }
    public bool IsDeleted { get; set; }
    public string? Email { get; set; }
    public RoleDtoLogic? Role { get; set; }
}

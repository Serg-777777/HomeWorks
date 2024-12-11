

namespace Application.DtoLogics.UserDtoLogics;

public class UserFullDtoLogic
{
    public int Id { get; set; }
    public DateTime DateCreated { get; set; }
    public bool IsDeleted { get; set; } = false;
    public string? Login { get; set; }
    public string? Email { get; set; }
}

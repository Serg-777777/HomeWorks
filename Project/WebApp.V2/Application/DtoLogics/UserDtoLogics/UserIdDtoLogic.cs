

using Infrastructure.DtoLogics.UserDtoLogics;

namespace Application.DtoLogics.UserDtoLogics;

public class UserIdDtoLogic:IUserDtoLogic
{
    public int Id { get;private set; }
    public string? Login { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public UserIdDtoLogic(int id)
    {
        Id = id;
    }

}

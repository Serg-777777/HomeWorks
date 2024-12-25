namespace Infrastructure.DtoLogics.UserDtoLogics;

public class UserProfileDtoLogic:IUserDtoLogic
{
    public string? FirstName { get;  set; }
    public string? LastName { get; set; }
    public string? Country { get;  set; }
    public string? City { get;  set; }
    public int? Age { get;  set; }
    public int? UserModelId { get; set; }
}

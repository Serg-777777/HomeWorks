

using Domain.Models.UserModels;

namespace Application.DtoLogics.UserDtoLogics;

public class UserFullDtoLogic
{
    public UserFullDtoLogic() { }
    public int Id { get; set; }
    public string? Login { get; set; }
    public DateTime DateCreated { get; set; }
    public bool IsDeleted { get; set; }
    public string? Email { get; set; }
    public UserRoleModel? Role { get; set; }
    public UserProfileModel? ProfileModel { get; set; }
}

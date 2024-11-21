

using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.UserModel
{
    [ComplexType]
    public class UserRoleModel
    {
        public required string RoleUser { set; get; }
    }
}

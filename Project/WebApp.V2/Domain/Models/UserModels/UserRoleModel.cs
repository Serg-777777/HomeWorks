

using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.UserModels;

    [ComplexType]
    public partial class UserRoleModel
    {
        public required string RoleUser { set; get; }
    }


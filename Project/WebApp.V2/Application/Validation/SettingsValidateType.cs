

namespace Application.Validation;

[Flags]
 public enum SettingsValidateType
{
    Login,
    Password,
    Id,
    Email
}

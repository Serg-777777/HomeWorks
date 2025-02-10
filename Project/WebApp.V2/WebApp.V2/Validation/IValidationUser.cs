
using FluentValidation.Results;
using Presentation.DtoViews.UserDtoViews;

namespace Presentation.Validation;

public interface IValidationUser
{
    internal ValidationResult ValidateId(int id);
    internal ValidationResult ValidateAutirize(string login, string password);
    internal ValidationResult ValidateUserDtoView(UserDtoView userDto);
    internal ValidationResult ValidateUserEditDtoView(UserEditDtoView userDto);
}


using FluentValidation.Results;
using Presentation.DtoViews.UserDtoViews;

namespace Presentation.Validation;

public interface IValidationUser
{
    internal ValidationResult Validate(int id);
    internal ValidationResult Validate(string login, string password);
    internal ValidationResult Validate(UserDtoView userDto);
    internal ValidationResult Validate(UserEditDtoView userDto);
}

using FluentValidation.Results;
using Presentation.DtoViews.UserDtoViews;

namespace Presentation.Validation;

public interface IValidationUserProfile
{
    ValidationResult Validate(int id);
    ValidationResult Validate(int id, UserProfileDtoView profileDtoView);
}

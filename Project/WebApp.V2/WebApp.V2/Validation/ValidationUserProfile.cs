using FluentValidation.Results;
using Presentation.DtoViews.UserDtoViews;
using Presentation.Validation.Validators;
using Presentation.Validation.Validators.UserProfileValidators;

namespace Presentation.Validation
{
    public class ValidationUserProfile : IValidationUserProfile
    {
        public ValidationResult Validate(int id)
        {
            var valid = new IdValidator();
            var res = valid.Validate(id);
            return res;

        }

        public ValidationResult Validate(int id, UserProfileDtoView profileDtoView)
        {
            var valid = new UserProfileDtoValidator();
            var res = valid.Validate(profileDtoView);
            if(res.IsValid) res = Validate(id);
            return res;
        }
    }
}

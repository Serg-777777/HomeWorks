using FluentValidation;
using Presentation.DtoViews.UserDtoViews;

namespace Presentation.Validation.Validators
{
    public class UserDtoViewValidator:AbstractValidator<UserDtoView>
    {
        public UserDtoViewValidator()
        {
            RuleFor(p=>p.Login).SetValidator(new LoginValidator()!);
            RuleFor(p => p.Email).SetValidator(new EmailValidator()!);
            RuleFor(p => p.Password).SetValidator(new PasswordValidator()!);
        }
    }
}

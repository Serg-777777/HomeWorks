using FluentValidation;
using Presentation.Validation.Records;

namespace Presentation.Validation.Validators
{
    public class LoginValidator:AbstractValidator<string>
    {
        public LoginValidator()
        {
            RuleFor(v=>v)
                .NotNull()
                .NotEmpty()
                .MinimumLength(ValidationSettings.LoginMinimumLength)
                .MaximumLength(ValidationSettings.LoginMaximumLength)
                .WithMessage(ValidationSettings.LoginMSG);
        }
    }
}

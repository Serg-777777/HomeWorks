using FluentValidation;

namespace Presentation.Validation.Validators
{
    internal class PasswordValidator:AbstractValidator<string>
    {
        public PasswordValidator()
        {
            RuleFor(v => v)
                .NotNull()
                .NotEmpty()
                .MinimumLength(ValidationSettings.PassMinimumLength)
                .MaximumLength(ValidationSettings.PassMaximumLength)
                .WithMessage(ValidationSettings.LoginMSG);
        }
    }
}

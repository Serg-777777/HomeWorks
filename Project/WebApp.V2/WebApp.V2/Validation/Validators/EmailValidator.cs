using FluentValidation;

namespace Presentation.Validation.Validators;

public class EmailValidator:AbstractValidator<string>
{
    public EmailValidator()
    {
        RuleFor(p => p)
            .NotNull()
            .EmailAddress()
            .MaximumLength(ValidationSettings.EmailMaximumLength)
            .WithMessage(ValidationSettings.EmailMSG);
    }
}

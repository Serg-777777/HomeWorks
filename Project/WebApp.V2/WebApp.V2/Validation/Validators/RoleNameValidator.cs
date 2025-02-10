using FluentValidation;

namespace Presentation.Validation.Validators;

public class RoleNameValidator:AbstractValidator<string>
{
    public RoleNameValidator()
    {
        RuleFor(p => p)
            .NotNull()
            .MinimumLength(ValidationSettings.RoleMinimumLength)
            .MaximumLength(ValidationSettings.RoleMaximumLength)
            .WithMessage(ValidationSettings.RoleMSG);
    }
}

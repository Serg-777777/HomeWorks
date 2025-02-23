using FluentValidation;

namespace Presentation.Validation.Validators;

public class IdValidator : AbstractValidator<int>
{
    public IdValidator()
    {
        RuleFor(r => r)
            .NotNull()
            .LessThan(ValidationSettings.IdLessThan)
            .GreaterThan(ValidationSettings.IdGreaterThan)
            .WithMessage(ValidationSettings.IdMSG);
    }
}

using FluentValidation;
using FluentValidation.Results;
using Presentation.Validation.Records;

namespace Presentation.Validation.Validators;

internal class AuthorizeValidator : AbstractValidator<AuthorizeValidationRecords>
{
    public AuthorizeValidator()
    {
        RuleFor(o=> o.login).SetValidator(new LoginValidator());
        RuleFor(o => o.password).SetValidator(new PasswordValidator());
    }
}

using FluentValidation;
using Presentation.DtoViews.UserDtoViews;

namespace Presentation.Validation.Validators;

public class UserEditDtoViewValidator :AbstractValidator<UserEditDtoView>
{
    public UserEditDtoViewValidator()
    {
        RuleFor(p=>p.Email).SetValidator(new  EmailValidator()!);
        RuleFor(p=>p.Id).SetValidator(new IdValidator());
        RuleFor(p=>p.Login).SetValidator(new  LoginValidator()!);
        RuleFor(p => p.Role!.RoleName).SetValidator(new RoleNameValidator());
    }
}


using FluentValidation.Results;
using Presentation.DtoViews.UserDtoViews;
using Presentation.Validation.Records;
using Presentation.Validation.Validators;

namespace Presentation.Validation
{
    internal sealed class ValidationUser : IValidationUser
    {
        public ValidationResult ValidateAutirize(string login, string password)
        {
            var valid = new AuthorizeValidator();
            var res = valid.Validate(new AuthorizeValidationRecords(login, password));
            return res;
        }

        public ValidationResult ValidateId(int id)
        {
            var valid = new IdValidator();
            var res = valid.Validate(id);
            return res;
        }

        public ValidationResult ValidateUserDtoView(UserDtoView userDto)
        {
            var valid = new UserDtoViewValidator();
            var res = valid.Validate(userDto);
            return res;
        }

        public ValidationResult ValidateUserEditDtoView(UserEditDtoView userDto)
        {
            var valid = new UserEditDtoViewValidator();
            var res = valid.Validate(userDto);
            return res;
        }
    }
}

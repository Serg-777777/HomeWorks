
using FluentValidation.Results;
using Presentation.DtoViews.UserDtoViews;
using Presentation.Validation.Records;
using Presentation.Validation.Validators;

namespace Presentation.Validation
{
    internal sealed class ValidationUser : IValidationUser
    {
        public ValidationResult Validate(string login, string password)
        {
            var valid = new AuthorizeValidator();
            var res = valid.Validate(new AuthorizeValidationRecords(login, password));
            return res;
        }

        public ValidationResult Validate(int id)
        {
            var valid = new IdValidator();
            var res = valid.Validate(id);
            return res;
        }

        public ValidationResult Validate(UserDtoView userDto)
        {
            var valid = new UserDtoViewValidator();
            var res = valid.Validate(userDto);
            return res;
        }

        public ValidationResult Validate(UserEditDtoView userDto)
        {
            var valid = new UserEditDtoViewValidator();
            var res = valid.Validate(userDto);
            return res;
        }
    }
}

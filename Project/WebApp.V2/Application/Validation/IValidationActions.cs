

namespace Application.Validation;

public interface IValidationActions
{
    public ResultValidation IsValidObject(dynamic obj);
    public ResultValidation IsValid(params (SettingsValidateType setting, dynamic value)[] values);
}

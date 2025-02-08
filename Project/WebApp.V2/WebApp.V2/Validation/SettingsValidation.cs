using Application.Validation;
using Presentation.DtoViews.UserDtoViews;
namespace Presentation.Validation;

class SettingValidation : SettingsValidationBase
{
    private SettingsValuesValidation _valuesValidation;
    protected SettingValidation()
    {
        _valuesValidation = SettingsValuesValidation.GetInstance();
        SetValidationMethod(SettingsValidateType.Id, OnValidId);
        SetValidationMethod(SettingsValidateType.Login, OnValidLogin);
        SetValidationMethod(SettingsValidateType.Password, OnValidPassword);
        SetValidationMethod(SettingsValidateType.Email, OnValidEmail);
    }
    public override ResultValidation IsValidObject(dynamic obj)
    {
        ResultValidation res = new ResultValidation(false, "default");

        if (obj is UserDtoView)
        {
            res = ValidateUserDtoView(obj);
        }
        if (obj is UserEditDtoView)
        {
            res = ValidateUserEditDtoView(obj);
        }
        return res;
    }
    private ResultValidation ValidateUserEditDtoView(UserEditDtoView obj)
    {
        var res = OnValidLogin(obj.Login!);
        if (res.IsValid) res = OnValidEmail(obj.Email!);
        if (res.IsValid) res = OnValidId(obj.Id);
        if (res.IsValid) res = OnValidLogin(obj.Role?.RoleName!);

        return res;
    }
    private ResultValidation ValidateUserDtoView(UserDtoView obj)
    {
        var res = OnValidLogin(obj.Login!);
        if (res.IsValid)
            res = OnValidPassword(obj.Password!);
        if (res.IsValid)
            res = OnValidEmail(obj.Email!);
        return res!;
    }

    private bool StringIntersect(string source, char[] notContainsChar)
    {
        var s = source.ToCharArray();
        var c = s.Intersect(notContainsChar).Count();
        if (c > 0) return true;
        return false;
    }

    private bool StringNullAndLenght(string? str, int minValue, int maxValue)
    {
        var res = (str == null || str.Length < minValue || str.Length > maxValue);
        return res;
    }
    protected override ResultValidation OnValidEmail(dynamic value)
    {
        if (StringIntersect(value, _valuesValidation.CharsNotContaints))
            return new ResultValidation(false, "Email содержит недопустимые символы");
        if (StringNullAndLenght(value, _valuesValidation.EmaiMin, _valuesValidation.EmaiMax))
            return new ResultValidation(false, "Email не корректен");
        return new ResultValidation(true, "Ok");
    }
    protected override ResultValidation OnValidId(dynamic value)
    {
        var res = value is int;
        if (!res) return new ResultValidation(false, "ID не соответствует тип");
        res = StringNullAndLenght((string)value, _valuesValidation.IdMin, _valuesValidation.IdMax);
        if (res) return new ResultValidation(false, "ID не корректен");
        return new ResultValidation(true, "Ok");
    }

    protected override ResultValidation OnValidLogin(dynamic value)
    {
        string str = (string)value;
        if (StringNullAndLenght(str, _valuesValidation.NameMin, _valuesValidation.NameMax))
            return new ResultValidation(false, "Login не корректен");
        if (StringIntersect(str, _valuesValidation.CharsNotContaints))
            return new ResultValidation(false, "Login содержит недопустимые символы");
        return new ResultValidation(true, "Ok"); ;
    }

    protected override ResultValidation OnValidPassword(dynamic value)
    {
        string str = (string)value;
        if (StringNullAndLenght(str, _valuesValidation.PasswordMin, _valuesValidation.PasswordMax))
            return new ResultValidation(false, "Password не корректенt");
        if (StringIntersect(str, _valuesValidation.CharsNotContaints))
            return new ResultValidation(false, "Password содержит недопустимые символы");
        return new ResultValidation(true, "Ok");
    }

}

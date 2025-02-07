using Application.Validation;
using Presentation.DtoViews.UserDtoViews;
namespace Presentation.Validation;

class SettingValidation : SettingsValidationBase
{
    private SettingValuesValidation _valuesValidation;
    protected SettingValidation()
    {
        _valuesValidation = SettingValuesValidation.GetInstance();
        SetValidationMethod(SettingsValidateType.Id, OnValidId);
        SetValidationMethod(SettingsValidateType.Login, OnValidLogin);
        SetValidationMethod(SettingsValidateType.Password, OnValidPassword);
        SetValidationMethod(SettingsValidateType.Email, OnValidEmail);
    }
    public override ResultValidation IsValidObject(dynamic obj)
    {
        ResultValidation res = new ResultValidation(false, "default");

        if (obj is UserDtoView dto)
        {
            res = ValidateUserDtoView(dto);
        }
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

    protected override ResultValidation OnValidEmail(dynamic value)
    {
        if (StringIntersect(value, _valuesValidation.CharsNotContaints))
            return new ResultValidation(false, "Email не корректен");
        return new ResultValidation(true, "Ok");
    }
    protected override ResultValidation OnValidId(dynamic value)
    {
        var res = value is int;
        if (!res) return new ResultValidation(false, "ID не корректен");
        return new ResultValidation(true, "Ok");
    }

    protected override ResultValidation OnValidLogin(dynamic value)
    {
        string v = (string)value;
        if (v == null || v.Length <= _valuesValidation.NameMin || v.Length >= _valuesValidation.NameMax)
            return new ResultValidation(false, "Login не корректен");
        if (StringIntersect(v, _valuesValidation.CharsNotContaints))
            return new ResultValidation(false, "Login содержит недопустимые символы");
        return new ResultValidation(true, "Ok"); ;
    }

    protected override ResultValidation OnValidPassword(dynamic value)
    {
        string v = (string)value;
        if (v == null || v.Length <= _valuesValidation.PasswordMin || v.Length >= _valuesValidation.PasswordMax)
            return new ResultValidation(false, "Password не корректенt");
        if (StringIntersect(v, _valuesValidation.CharsNotContaints))
            return new ResultValidation(false, "Password содержит недопустимые символы");
        return new ResultValidation(true, "Ok");
    }

}

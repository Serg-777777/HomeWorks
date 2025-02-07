

namespace Application.Validation;

public abstract class SettingsValidationBase
{
    private Dictionary<SettingsValidateType, Func<dynamic, ResultValidation>> _settingsLiist;
    public SettingsValidationBase()
    {
        _settingsLiist = new();
    }

    protected void SetValidationMethod(SettingsValidateType validateType, Func<dynamic, ResultValidation> method)
    {
        if (!_settingsLiist.ContainsKey(validateType))
            _settingsLiist.Add(validateType, method);
        else
            _settingsLiist[validateType] = method;
    }
    protected Func<dynamic, ResultValidation> GetValidationMethod(SettingsValidateType validateType)
    {
        var val = _settingsLiist.FirstOrDefault (v => v.Key == validateType);
        return val.Value;
    }
    
    public virtual ResultValidation IsValid(params (SettingsValidateType setting, dynamic value)[] values)
    {
        ResultValidation res = default!;
        foreach(var v in values)
        {
            var act = GetValidationMethod(v.setting);
            if (act == default) return new ResultValidation(false,"Method not exist");
            res = act.Invoke(v.value);
            if (!res.IsValid) break;
        }
        return res;
    }
    public abstract ResultValidation IsValidObject(dynamic obj);
    protected abstract ResultValidation OnValidId(dynamic value);
    protected abstract ResultValidation OnValidLogin(dynamic value);
    protected abstract ResultValidation OnValidPassword(dynamic value);
    protected abstract ResultValidation OnValidEmail(dynamic value);
}



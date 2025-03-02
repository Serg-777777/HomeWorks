

namespace HW_8.PatternPrototype.Auto.Cars;

internal class AutoPartsSetting : AutoBase, IAutoPartsSetting<AutoBase>
{
    public AutoPartsSetting(AutoBase autoBase) : base(autoBase.Brand!)
    {
    }

    public AutoBase GetAutoBase()
    {
        return this;
    }

    public virtual void SetBody(IBody body)
    {
        base.ChangeBody(body);
    }

    public virtual void SetEngie(IEngie engie)
    {
        base.ChangeEngie(engie);
    }

    public virtual void SetInfo(IInfo info)
    {
        base.ChangeInfo(info);
    }
}

namespace HW_8.PatternPrototype.Auto.Cars.Brands.Toyota;

[Serializable]
internal class Toyota : AutoBase, IAutoPartsSetting<AutoBase>
{
    private const string _brandAuto = "Toyota";

    public Toyota() : base(_brandAuto) { }

    public AutoBase GetAutoBase()
    {
        return this;
    }
    public virtual void SetInfo(IInfo info)
    {
        base.ChangeInfo(info);
    }
    public virtual void SetEngie(IEngie engie)
    {
        base.ChangeEngie(engie);
    }
    public virtual void SetBody(IBody body)
    {
        base.ChangeBody(body);
    }
}

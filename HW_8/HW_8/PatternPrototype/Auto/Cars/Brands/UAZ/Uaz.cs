
namespace HW_8.PatternPrototype.Auto.Cars.Brands.UAZ;

internal class Uaz : AutoBase, IAutoPartsSetting<AutoBase>
{
    private const string _brand = "UAZ";

    public Uaz():base(_brand) { }

    public AutoBase GetAutoBase()
    {
        return this;
    }
    public void SetInfo(IInfo info)
    {
        base.ChangeInfo(info);
    }
    public void SetEngie(IEngie engie)
    {
        base.ChangeEngie(engie);
    }
    public void SetBody(IBody body)
    {
        base.ChangeBody(body);
    }
}

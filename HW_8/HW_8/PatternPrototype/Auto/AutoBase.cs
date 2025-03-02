

namespace HW_8.PatternPrototype.Auto;

[Serializable]
internal abstract class AutoBase
{
    public IBody? Body { get; private set; } = null;
    public IEngie? Engie { get; private set; } = null;
    public IInfo? Info { get; private set; } = null;
    public string? Brand { get; init; } = null;

    public AutoBase() { }
    protected AutoBase(string brand)
    {
        Brand = brand;
    }
    protected AutoBase(string brand, IBody? body, IEngie? engie, IInfo? info)
    {
        Brand = brand;
        Body = body;
        Engie = engie;
        Info = info;
    }

    protected virtual void ChangeBody(IBody body)
    {
        Body = body;
    }
    protected virtual void ChangeEngie(IEngie engie)
    {
        Engie = engie;
    }
    protected virtual void ChangeInfo(IInfo info)
    {
        Info = info;
    }

}

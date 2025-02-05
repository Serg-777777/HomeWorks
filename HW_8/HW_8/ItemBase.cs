

namespace HW_8;

internal abstract class ItemBase : ICloneable
{
    private string _desc;
    private static int _inx = 0;

    public int ID { get; init; }
    public string? Desc { get => _desc; }
    public ItemBase(string desc)
    {
        ID = _inx++;
        _desc = desc + "_" + ID;

    }
    public abstract object Clone();
    public void ChangeDesc(string desc)
    {
        _desc = desc;
    }
    public override string ToString()
    {
        return $"Id: {ID} Desc: {Desc}";
    }

}

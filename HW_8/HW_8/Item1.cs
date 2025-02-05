

namespace HW_8;

internal class Item1 : ItemBase
{
    public Item1(string desc) : base(desc) {}

    public override object Clone()
    {
        var obj = SamplesFactory.GetClone<Item1>(this);
        return obj!;
    }
}

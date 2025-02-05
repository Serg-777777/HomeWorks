

namespace HW_8;

internal class Item2 : Item1
{
    public Item2(string desc) : base(desc){}
    public override object Clone()
    {
        var obj = SamplesFactory.GetClone<Item2>(this);
        return obj!;
    }
}

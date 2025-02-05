
namespace HW_8;

internal class Item : ItemBase
{
    public Item(string desc) : base(desc){}

    public override object Clone()
    {
        var obj = SamplesFactory.GetClone<Item>(this);
        return obj!;
    }
}

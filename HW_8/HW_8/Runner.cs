

namespace HW_8;

internal sealed class Runner
{
    public void Run(Action<string> debuger)
    {
        var item = new Item("item");
        var item1 = new Item("item1");
        var item2 = new Item("item2");

        var clone = item.Clone();
        var clone1 = item1.Clone();
        var clone2 = item2.Clone();

        debuger.Invoke("---items---");
        debuger.Invoke(item.ToString());
        debuger.Invoke(item1.ToString());
        debuger.Invoke(item2.ToString());

        item.ChangeDesc("test");
        item1.ChangeDesc("test1");
        item1.ChangeDesc("test2");

        debuger.Invoke("---items test---");

        debuger.Invoke(item.ToString());
        debuger.Invoke(item1.ToString());
        debuger.Invoke(item2.ToString());

        debuger.Invoke("---clones---");

        debuger.Invoke(clone.ToString()!);
        debuger.Invoke(clone1.ToString()!);
        debuger.Invoke(clone2.ToString()!);

    }
}

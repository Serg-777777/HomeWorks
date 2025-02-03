

namespace HW_7;

internal class Calculater
{
    CollectionsBuilder _collectionsBuilder = new();
    private int _count = 0;
    public Calculater(int count)
    {
        _count = count;
    }

    public int SumSync()
    {

        var arr = _collectionsBuilder.GetEnumerable(_count);
        var sum = 0;
        foreach (var i in arr)
        {
            sum += i;
        }
        return sum;
    }

    public int SumThread()
    {
        var arr = _collectionsBuilder.GetEnumerable(_count);
        var sum = 0;

        Thread thread = new Thread(
             (object? a) =>
             {
                 IEnumerable<int> mas = (IEnumerable<int>)a!;
                 foreach (var i in mas)
                 {
                     sum += i;
                 }
             });
        thread.Start((object)arr);
        thread.Join();

        return sum;
    }

    public int SumParallel()
    {
        int sum = 0;
        var arr = _collectionsBuilder.GetEnumerableParallel(_count);
        Parallel.ForEach<int>(arr, v =>
        {
            Interlocked.Add(ref sum, v);
        });
        return sum;
    }

    public int SumLinq()
    {
        int sum = 0;
        var arr = _collectionsBuilder.GetPatitioner(_collectionsBuilder.GetEnumerableParallel(_count));
        var c = arr.AsParallel().Select(val => sum += val).Count();

        return sum;
    }

    public int SumPatitioner()
    {
        var arr = _collectionsBuilder.GetPatitioner(_collectionsBuilder.GetEnumerable(_count));
        var sum = arr.AsParallel().Aggregate((val1, val2) => val1 +=val2 );
        
        return sum;
    }
}

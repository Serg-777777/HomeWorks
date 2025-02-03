
using System.Collections.Concurrent;


namespace HW_7;

internal class CollectionsBuilder
{
    public IEnumerable<int> GetEnumerable(int count)
    {
        var range = Enumerable.Range(0, count);
        return range;
    }
    public IEnumerable<int> GetEnumerableParallel(int count)
    {
        var range = ParallelEnumerable.Range(0, count);
        return range;
    }
    public OrderablePartitioner<int> GetPatitioner(IEnumerable<int> list)
    {
        var part = Partitioner.Create<int>(list);
        return part;
    }
}

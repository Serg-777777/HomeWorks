

namespace HW_7;

internal class Runner
{
    private Calculater _calculater=default!;
    public Runner(Calculater calculater)
    {
        _calculater = calculater;
    }
    public void RunSumSync()
    {
        var sum = _calculater.SumSync();
        Console.WriteLine($"Sum Sync: {sum}");
    }
    public void RunSumThread()
    {
        var sum = _calculater.SumThread();
        Console.WriteLine($"Sum Thread: {sum}");
    }
    public void RunSumParallel()
    {
        var sum = _calculater.SumParallel();
        Console.WriteLine($"Sum Parallel: {sum}");
    }
    public void RunSumLinq()
    {
        var sum = _calculater.SumLinq();
        Console.WriteLine($"Sum Linq: {sum}");
    }
    public void RunSumPatitioner()
    {
        var sum = _calculater.SumPatitioner();
        Console.WriteLine($"Sum Patitioner: {sum}");
    }
}

using BenchmarkDotNet.Running;

namespace HW_Reflection;

internal class Program
{
    static void Main(string[] args)
    {
        BenchmarkRunner.Run<Runner>();
    }
}

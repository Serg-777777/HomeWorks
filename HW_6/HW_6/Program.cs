
using Microsoft.VisualBasic.FileIO;
using System.Diagnostics;

namespace HW_6;


internal class Program
{
    static void Main(string[] args)
    {
        string dirPath = Directory.GetCurrentDirectory();
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Tester.txt");
        Stopwatch sw = new();

        var runner = new RunnerSeacher();
        sw.Start();
        runner.SearcherRun(dirPath);
        sw.Stop();
        Console.WriteLine($"Watcher Searcher: {sw.ElapsedMilliseconds}");
        sw.Reset();

        sw.Start();
        runner.SearcherRunAsync(filePath);
        sw.Stop();
        Console.WriteLine($"Watcher SearcherAsync: {sw.ElapsedMilliseconds}");
    }
}

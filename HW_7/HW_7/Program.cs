using System.Diagnostics;

namespace HW_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(5000);
            Excute(100000);
            Thread.Sleep(5000);
            Excute(1000000);
            Thread.Sleep(5000);
            Excute(10000000);
        }

        private  static void Excute(int max)
        {

            Calculater calculater = new(max);
            Runner runner = new(calculater);
            Stopwatch sw = new Stopwatch();

            Console.WriteLine($"=====COUNT: {max}=====");
            sw.Start();
            runner.RunSumSync();
            sw.Stop();
            Console.WriteLine($"<Watch Sync: {sw.ElapsedMilliseconds}\n");
            sw.Reset();

            sw.Start();
            runner.RunSumThread();
            sw.Stop();
            Console.WriteLine($"<Watch Thread: {sw.ElapsedMilliseconds}\n");
            sw.Reset();

            sw.Start();
            runner.RunSumParallel();
            sw.Stop();
            Console.WriteLine($"<Watch Parallel: {sw.ElapsedMilliseconds}\n");
            sw.Reset();

            sw.Start();
            runner.RunSumLinq();
            sw.Stop();
            Console.WriteLine($"<Watch Linq: {sw.ElapsedMilliseconds}\n");
            sw.Reset();

            sw.Start();
            runner.RunSumPatitioner();
            sw.Stop();
            Console.WriteLine($"<Watch Patitioner: {sw.ElapsedMilliseconds}\n");
            sw.Reset();
            Console.WriteLine($"==================\n");
        }

    }

}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace Async
{
    class Program
    {
        static async void Main(string[] args)
        {
            WriteLine("Loading...");
            await WaitForIt();
            await WaitForIt2();
        }

        public static async Task WaitForIt()
        {
            Task.Delay(TimeSpan.FromSeconds(5));
            WriteLine("Five seconds complete");
        }
        public static async Task WaitForIt2()
        {
            await Task.Delay(10000);
            WriteLine("Ten seconds complete");
        }
    }
    class Parallel
    {
        public static async Task<long> Main()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            //await Process1();
            //await Process2();

            var task1 = Process1();
            var task2 = Process2();

            await Task.WhenAll(task1, task2);//Cuando acaben las dos
            //await Task.WhenAny(task1, task2);//Cuando acabe una

            stopwatch.Stop();

            return stopwatch.ElapsedMilliseconds;
        }

        public static async Task Process1()
        {
            await Task.Run(() =>
                   Thread.Sleep(4000)
                );
        }

        public static async Task Process2()
        {
            await Task.Run(() =>
                   Thread.Sleep(1000)
                );
        }
    }
}

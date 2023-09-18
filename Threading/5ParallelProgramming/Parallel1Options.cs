using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Threading.ParallelProgramming
{
    public static class Parallel1Options
    {
        public static  void runTask()
        {
            Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Started");

            int length = 10;
            Console.WriteLine("C# parallel for loop");

            Stopwatch _watch = Stopwatch.StartNew();
            ParallelOptions _option = new ParallelOptions
            {
                MaxDegreeOfParallelism = 2
            };
            
            Parallel.For(0, length,_option, count =>
            {
                Console.WriteLine($"the value is {count} and Thread : {Thread.CurrentThread.ManagedThreadId} ");
                Thread.Sleep(10);
            });

            _watch.Stop();
            Console.WriteLine("time taken " + _watch.ElapsedMilliseconds);

            Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Completed");

        }


    }


    }

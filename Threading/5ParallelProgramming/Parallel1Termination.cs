using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Threading.ParallelProgramming
{
    public static class Parallel1Termination
    {
        public static  void runTask()
        {
            Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Started");

            int length = 500;
            int data = 0;
            Console.WriteLine("C# parallel for loop");

            Stopwatch _watch = Stopwatch.StartNew();

            Parallel.For(0, length, (count, breakcount) =>
            {
                data += count;
                if (data>100)
                {
                    Console.WriteLine($"Encounter Break {data}");
                    breakcount.Break();
                }
                Console.WriteLine($"the value is {count} and Thread : {Thread.CurrentThread.ManagedThreadId} ");
                Thread.Sleep(10);
            });

            _watch.Stop();
            Console.WriteLine("time taken " + _watch.ElapsedMilliseconds);

            Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Completed");

        }


    }


    }

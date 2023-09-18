using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Threading.ParallelProgramming
{
    public static class Parallel2ForEach
    {
        public static  void runTask()
        {
            Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Started");


            List<int> collection = Enumerable.Range(0, 10).ToList();

            
            Console.WriteLine("C# standard foreach loop");

            Stopwatch _watch = Stopwatch.StartNew();
            foreach(var item in collection)
            {
                Console.WriteLine($" the value is {item} and Thread : {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(10);
            }
            _watch.Stop();
            Console.WriteLine("time taken " + _watch.ElapsedMilliseconds);

            Console.WriteLine("C# parallel foreach loop");

            _watch = Stopwatch.StartNew();
            Parallel.ForEach(collection, i =>
            {
                Console.WriteLine($" the value is {i} and Thread : {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(10);
            });

            _watch.Stop();
            Console.WriteLine("time taken " + _watch.ElapsedMilliseconds);

            Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Completed");

        }


    }


    }

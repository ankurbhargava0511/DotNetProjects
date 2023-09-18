using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threading.AsyncProgramming
{
    public static class Task6ContinueWithSingleTaskExample
    {
        public static void runTask()
        {
            Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Started");

            Task<string> task1 = Task.Run(() =>
            {
                Console.WriteLine("This is Task1");
                return Total(5);
            }).ContinueWith((info) =>
            {
                Console.WriteLine("This is Task2 with continuation");
                return "the result is " + info.Result;
            });

            Console.WriteLine(task1.Result);
            Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Completed");
        }

        static int Total(int Max)
        {
            int sum = 0;
            Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Started");
            for (int count = 1; count <= Max; count++)
            {
                sum = sum + count;
            }
            Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Completed");
            return sum;
        }

    }


}

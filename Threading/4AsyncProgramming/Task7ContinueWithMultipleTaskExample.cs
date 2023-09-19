using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threading.AsyncProgramming
{
    public static class Task7ContinueWithMultipleTaskExample
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
                return "the result is " + info.Result;
            }).ContinueWith((atnecedent) => {

                return "the new result is " + atnecedent.Result;

            });

            task1.ContinueWith((details) =>
            {
                Console.WriteLine("new continue with method");
            });

            Console.WriteLine(task1.Result);

            Task.Delay(10000).ContinueWith((details) =>
            {
                Console.WriteLine("Continue with delay .continue with delay with method");
            });

            

            Task.Delay(1000).Wait();
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

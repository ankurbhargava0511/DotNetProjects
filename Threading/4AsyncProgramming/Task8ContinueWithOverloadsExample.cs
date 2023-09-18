using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threading.AsyncProgramming
{
    public static class Task8ContinueWithOverloadsExample
    {
        public static void runTask()
        {
            Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Started");


            Task<string> task1 = Task.Run(() =>
            {
                return Total(5);
            }).ContinueWith((info) =>
            {
                return "the result is " + info.Result;
            }).ContinueWith((atnecedent) => {

                return "the new result is " + atnecedent.Result;

            });

            task1.ContinueWith((details) =>
            {
                Console.WriteLine("Is task Faulted " + details.IsFaulted);
                Console.WriteLine("Task Has Exception " + details.Exception?.Message);
                Console.WriteLine("Is task completed " + details.IsCompleted);
                Console.WriteLine("Is task Cancelled " + details.IsCanceled);
            });

            task1.ContinueWith((info) =>
            {
                Console.WriteLine("Execute when Task is Faulted");
            }, TaskContinuationOptions.OnlyOnFaulted);

            task1.ContinueWith((info) =>
            {
                Console.WriteLine("Execute when Task is canceled");
            }, TaskContinuationOptions.OnlyOnCanceled);

            task1.ContinueWith((info) =>
            {
                Console.WriteLine("Execute When Task is  completed");
            }, TaskContinuationOptions.OnlyOnRanToCompletion);

            Console.WriteLine(task1.Result);

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

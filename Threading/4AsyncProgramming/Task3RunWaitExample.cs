using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threading.AsyncProgramming
{
    public static class Task3RunWaitExample
    {
        public static void runTaskWait()
        {
            Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Started");
            Task task1 = Task.Run(() => { PrintCounter(); });


            task1.Wait();


            Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Completed");
            
        }

        public static void runTaskWaitAll()
        {
            Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Started");
            Task task1 = Task.Run(() => { PrintCounter(); });
            Task task2 = Task.Run(() => { PrintCounter(); });

            Task.WaitAll(task1,task2);
            Console.WriteLine("Task1 Status:" + task1.Status);
            Console.WriteLine("Task2 Status:" + task2.Status);

            Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Completed");

        }


        public static void runTaskWaitAny()
        {
            Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Started");
            Task task1 = Task.Run(() => { PrintCounter(); });
            Task task2 = Task.Run(() => { PrintCounter(); });

            Task.WaitAny(task1, task2);

            Console.WriteLine("Task1 Status:" + task1.Status);
            Console.WriteLine("Task2 Status:" + task2.Status);


            Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Completed");

        }



        public static void runTaskWhenAny()
        {
            Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Started");
            Task task1 = Task.Run(() => { PrintCounter(); });
            Task task2 = Task.Run(() => { PrintCounter(); });

            Task.WhenAny(task1, task2);

            Console.WriteLine("Task1 Status:" + task1.Status);
            Console.WriteLine("Task2 Status:" + task2.Status);


            Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Completed");

        }

        static void PrintCounter()
        {
            Console.WriteLine("Call via Lambda Method.");
            Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Started");
            for (int count = 1; count <= 100; count++)
            {
                Console.WriteLine($"count value: {count}");
            }
            Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Completed");
        }

    }
}

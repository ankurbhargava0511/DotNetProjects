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
        static void PrintCounter()
        {
            Console.WriteLine("Call via Lambda Method.");
            Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Started");
            for (int count = 1; count <= 5; count++)
            {
                Console.WriteLine($"count value: {count}");
            }
            Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Completed");
        }

    }
}

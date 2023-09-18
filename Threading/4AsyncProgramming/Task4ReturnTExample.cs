using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threading.AsyncProgramming
{
    public static class Task4ReturnTExample
    {
        public static void runTaskReturn()
        {
            Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Started");
            Task<int> task1 = Task.Run(() => { 
                return Total(5); 
            });


            task1.Wait();

            Console.WriteLine("Sum is :-" + task1.Result);


            Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Completed");
            
        }
        static int Total(int max)
        {
            int sum = 0;
            Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Started");
            for (int count = 1; count <= max; count++)
            {
                sum= sum+count;
            }
            Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Completed");
            return sum;
        }

    }
}

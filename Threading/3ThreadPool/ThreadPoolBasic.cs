using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threading._3ThreadPool
{
    internal class ThreadPoolBasic
    {
        public static void CreateThreadPoolThread()
        {
            Console.WriteLine("Main method Started");
            for (int i = 0; i < 5; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadPoolMethod));
            }
            Console.WriteLine("Main method Completed");
            //Console.ReadLine();
        }

        public static void ThreadPoolMethod(object obj)
        {
            Thread thread = Thread.CurrentThread;
            string message = $"Background: {thread.IsBackground}, Thread Pool: {thread.IsThreadPoolThread}, Thread ID: {thread.ManagedThreadId}";
            Console.WriteLine(message);
        }
    }
}

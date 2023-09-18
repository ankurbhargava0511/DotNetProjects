using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threading._3ThreadPool
{
    internal class ThreadPoolVsThread
    {
        public static void CreateThreadPoolVsThread()
        {
            for (int i = 0; i < 5; i++)
            {
                MethodWithThread();
                MethodWithThreadPool();
            }
            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine("Execution using Thread");
            stopwatch.Start();
            MethodWithThread();
            stopwatch.Stop();
            Console.WriteLine("Time consumed by MethodWithThread is : " +
                                 stopwatch.ElapsedTicks.ToString());

            stopwatch.Reset();
            Console.WriteLine("Execution using Thread Pool");
            stopwatch.Start();
            MethodWithThreadPool();
            stopwatch.Stop();
            Console.WriteLine("Time consumed by MethodWithThreadPool is : " +
                                 stopwatch.ElapsedTicks.ToString());
        }

        public static void MethodWithThread()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread thread = new Thread(Test);
            }
        }
        public static void MethodWithThreadPool()
        {
            for (int i = 0; i < 5; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(Test));
            }
        }
        public static void Test(object obj)
        {
            // Console.WriteLine("Executing Task method");
        }
    }
}

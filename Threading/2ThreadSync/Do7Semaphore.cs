using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threading._2ThreadSync
{
    internal class Do7Semaphore
    {
        static Semaphore _event = new Semaphore(4,4);
        public static void DoSemaphore()
        {
            for (int i = 0; i < 20; i++)
            {
                new Thread(Write).Start();
            }

            Thread.Sleep(4000);
           
            //Console.ReadLine();
        }

        public static void Write()
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + "Write Thread Waiting");
            _event.WaitOne();
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + "Write Thread Working");

            Thread.Sleep(1000);
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + "Write Thread Completed");

            _event.Release();
        }


    }
}

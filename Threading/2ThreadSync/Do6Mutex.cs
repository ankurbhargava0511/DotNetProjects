using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threading._2ThreadSync
{
    internal class Do6Mutex
    {
        static Mutex _event = new Mutex();
        public static void DoMutex()
        {
            for (int i = 0; i < 5; i++)
            {
                new Thread(Write).Start();
            }

            Thread.Sleep(4000);
            _event.ReleaseMutex();
            //Console.ReadLine();
        }

        public static void Write()
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + "Write Thread Waiting");
            _event.WaitOne();
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + "Write Thread Working");

            Thread.Sleep(1000);
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + "Write Thread Completed");

            _event.ReleaseMutex();
        }


    }
}

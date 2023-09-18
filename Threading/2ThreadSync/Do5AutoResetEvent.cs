using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threading._2ThreadSync
{
    internal class Do5AutoResetEvent
    {
        static AutoResetEvent _event = new AutoResetEvent(true);
        public static void DoAutoReset()
        {
            for (int i = 0; i < 5; i++)
            {
                new Thread(Write).Start();
            }
            // Dont do this , if main thread set the value multi thread start executing
            //Thread.Sleep(4000);
            //_event.Set();
            //Console.ReadLine();
        }

        public static void Write()
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + "Write Thread Waiting");
            _event.WaitOne();
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + "Write Thread Working");

            Thread.Sleep(5000);
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + "Write Thread Completed");

            _event.Set();
        }


    }
}

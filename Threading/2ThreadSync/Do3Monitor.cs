using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threading._2ThreadSync
{
    internal class Do_3_Monitor
    {
        public static int Sum = 0;

        public void DoMonitor()
        {
            Console.WriteLine("Main method execution started");

            Stopwatch _watch = Stopwatch.StartNew();
            Thread t1 = new Thread(Addition);
            Thread t2 = new Thread(Addition);
            Thread t3 = new Thread(Addition);

            t1.Start();
            t2.Start();
            t3.Start();

            t1.Join();
            t2.Join();
            t3.Join();

            Console.WriteLine("Total sum is-" + Sum);

            _watch.Stop();

            Console.WriteLine("total tick time is:- " + _watch.ElapsedTicks);

            
        }

        public static object _lock = new object();

        public void Addition()
        {
            for (int l = 1; l < 50000; l++)
            {
                bool lockTaken = false;
                Monitor.Enter(_lock, ref lockTaken);
                try
                {
                    Sum++;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(_lock);
                }
            }
        }

    }
}

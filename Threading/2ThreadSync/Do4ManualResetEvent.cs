using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threading._2ThreadSync
{
    internal class Do4ManualResetEvent
    {

        static ManualResetEvent _mre = new ManualResetEvent(false);
        public static void DoManualReset()
        {
            Thread t1 = new Thread(Write);

            t1.Start();
            for (int i = 0; i < 5; i++)
            {
                new Thread(Read).Start();
            }


            //Console.ReadLine();
        }

        public static void Write()
        {
            Console.WriteLine("Write Thread Working");
            _mre.Reset();
            Thread.Sleep(5000);
            Console.WriteLine("Write Thread Completed");
            _mre.Set();
        }

        public static void Read()
        {
            Console.WriteLine("Read Thread Wait");
            _mre.WaitOne();
            Console.WriteLine("Read Thread Completed");
        }


    }
}

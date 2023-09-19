using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threading._2ThreadSync
{
    internal class Do7SemaphoreBounceExample
    {
        static Semaphore _event = new Semaphore(10,20);
        public static void DoSemaphore()
        {
            for (int i = 0; i < 60; i++)
            {
                ParameterizedThreadStart pts = new ParameterizedThreadStart(AddGuest);
                Thread PtsT = new Thread(pts);
                PtsT.Start(i);
               
            }

            Thread.Sleep(4000);
           
            Console.ReadLine();
        }

        public static void AddGuest(object GuestId)
        {
            Console.WriteLine(GuestId.ToString() + "Guest Waiting");
            _event.WaitOne();
            Thread.Sleep(2000);
            Console.WriteLine(GuestId.ToString() + "Guest enjoing food");

            Thread.Sleep(2000);
            Console.WriteLine(GuestId.ToString() + "Guest Leave");

            _event.Release();
        }


    }
}

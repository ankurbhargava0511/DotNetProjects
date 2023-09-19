using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threading._2ThreadSync;
using ThreadingBasic;

namespace Threading
{
    public static class ThreadingInGeneral
    {

        /*
         * Thread.IsBackgroud= True 
         */

        public static void ExecuteTests()
        {
            //Console.WriteLine("Hello, World!");

            //ThreadBasic cls = new ThreadBasic();
            //cls.RunThread();

            //Console.WriteLine("Thread Start , alive, etc, Join");
            //ThreadBasic2.StartTest();


            //Console.WriteLine("Thread Cancel/Abort");
            //ThreadCancel.runTask();


            //Console.WriteLine("Interlock");
            //Do_1_Interlock objI = new Do_1_Interlock();
            //objI.DoInterlock();

            //Do_1_Interlock2.TestCharacter();

            //Console.WriteLine("Lock");
            //Do_2_Lock objL = new Do_2_Lock();
            //objL.DoLock();
            //Console.WriteLine("Monitor");
            //Do_3_Monitor objM = new Do_3_Monitor();
            //objM.DoMonitor();

            //Console.WriteLine("Monitor2");
            //Do_3_Monitor2 objM2 = new Do_3_Monitor2();
            //objM2.DoMonitor2();

            //Console.WriteLine("ManualReset");
            //Do4ManualResetEvent.DoManualReset();



            //Console.WriteLine("AutoReset");
            //Do5AutoResetEvent.DoAutoReset();

            //Do5AutoResetEventandManualResetSignaling.TestBankTerminalWithManualReset();
            //Do5AutoResetEventandManualResetSignaling.TestBankTerminalWithAutoReset();

            //Do5zaCountDownEvent.TestCountdown();
            Do5zbBarrier.TestBarrier();

            //Console.WriteLine("Mutex");
            //Do6Mutex.DoMutex();

            //Console.WriteLine("Semaphore");
            //Do7Semaphore.DoSemaphore();



            //Console.WriteLine("Semaphore example with guest");
            //Do7SemaphoreBounceExample.DoSemaphore();

            //Console.WriteLine("Threadpool basic");
            //ThreadPoolBasic.CreateThreadPoolThread();


            //Console.WriteLine("Thread pool vs Thread performce");
            //ThreadPoolVsThread.CreateThreadPoolVsThread();

            //Console.WriteLine("with and without thread Performance");
            //ThreadsPerformance.ThreadsPerformanceTest();

            Console.ReadLine();


        }
    }
}

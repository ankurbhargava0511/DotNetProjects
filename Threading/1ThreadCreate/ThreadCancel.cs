using System.Threading;


namespace ThreadingBasic
{
    public static class ThreadCancel    
    {
        public static  void runTask()
        {
            Thread t1 = new Thread(methodFromThread);

            t1.Start();
            Thread.Sleep(10);

            t1.Abort();

            Console.WriteLine("after thread abort");



        }



        static void methodFromThread()
        {
            try
            {
                for (int i =0; i <=1000; i++)
                {
                    Console.WriteLine($"In Thread Execution {i}");
                }
                
            }
            catch(ThreadAbortException ex)
            {
                // You cannot use this outside call method
                Console.WriteLine("The thread is Aborted");
            }
            

        }

    }


    }

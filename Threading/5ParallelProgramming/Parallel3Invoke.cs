using System.Diagnostics;

namespace Threading.ParallelProgramming
{
    public static class Parallel3Invoke
    {
        public static  void runTask()
        {
            Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Started");
            var option = new ParallelOptions
            {
                MaxDegreeOfParallelism = -1
            };

            Parallel.Invoke(
                () => PrintNum(1),
                  () => PrintNum(1),
                  delegate ()
                  {
                      Parallel.For(0, 10, option => {
                          Console.WriteLine($"Anonymous method and  Thread : {Thread.CurrentThread.ManagedThreadId} Started");
                      });
                      
                  },

                  () =>
                  {
                      Parallel.For(0, 10, option => {
                          Console.WriteLine($"lembda method and  Thread : {Thread.CurrentThread.ManagedThreadId} Started");
                      });
                      
                  }
                );


            Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Completed");


        }

        static void PrintNum(int num)
        {
            Parallel.For(0, 10, option => {
                Console.WriteLine($"the num is {num} and  Thread : {Thread.CurrentThread.ManagedThreadId} Started");
            });

            
            Thread.Sleep(10);
        }
    }
}

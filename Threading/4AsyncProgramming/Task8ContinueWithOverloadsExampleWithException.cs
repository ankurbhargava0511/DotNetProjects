using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threading.AsyncProgramming
{
    public static class Task8ContinueWithOverloadsExampleWithException
    {
        public static void runTask()
        {
            var cts= new CancellationTokenSource();

            var childcts = CancellationTokenSource.CreateLinkedTokenSource(cts.Token);

            var t1 = Task.Run<int>(() => Total(cts.Token),cts.Token);
            Console.WriteLine("We pass cancellation , both to task and method. Task on will cancel the task and method will be use to take action on cancellation");

            //Thread.Sleep(10);
            //cts.Cancel();

            try
            {
                t1.Wait();
                //Console.WriteLine(t1.Result);
            }
            catch(AggregateException aex)
            {
                ReadOnlyCollection<Exception> rex = aex.InnerExceptions;

                var flatException = aex.Flatten().InnerExceptions;
                foreach(var  ex in flatException) 
                {
                    Console.WriteLine(ex);
                }
            }

            Console.WriteLine("Status of task :" + t1.Status);
        }

        static int Total(CancellationToken tok)
        { 
            throw new InvalidOperationException();
        }

    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threading.AsyncProgramming
{
    public static class Task8ContinueWithOverloadsExampleWithCancel
    {
        public static void runTask()
        {
            var cts= new CancellationTokenSource();

            var childcts = CancellationTokenSource.CreateLinkedTokenSource(cts.Token);

            var t1 = Task.Run<int>(() => Total(cts.Token),cts.Token);
            Console.WriteLine("We pass cancellation , both to task and method. Task on will cancel the task and method will be use to take action on cancellation");

            //Thread.Sleep(10);
            cts.Cancel();

            try
            {
                Console.WriteLine(t1.Result);
            }
            catch(AggregateException aex)
            {
                Console.WriteLine(aex.Message);
            }

            Console.WriteLine("Status of task :" + t1.Status);
        }

        public static void runTaskChildCanceled()
        {
            var cts = new CancellationTokenSource();

            var childcts = CancellationTokenSource.CreateLinkedTokenSource(cts.Token);

            Console.WriteLine("You can pass child token to lined taske. if cjild is cancel , parent has no effect but if parent is cancelled , child will be also be cancelled.");



            var t1 = Task.Run<int>(() => Total(cts.Token), cts.Token);
            var t2= Task.Run<int>(() => Total(childcts.Token), childcts.Token);
            Console.WriteLine("We pass cancellation , both to task and method. Task on will cancel the task and method will be use to take action on cancellation");

            //Thread.Sleep(10);
            childcts.Cancel();

            try
            {
                Console.WriteLine(t1.Result);
                Console.WriteLine(t2.Result);
            }
            catch (AggregateException aex)
            {
                Console.WriteLine(aex.Message);
            }

            Console.WriteLine("Status of task :" + t1.Status);
            Console.WriteLine("Status of task :" + t2.Status);
        }


        public static void runTaskParentCanceled()
        {
            var cts = new CancellationTokenSource();

            var childcts = CancellationTokenSource.CreateLinkedTokenSource(cts.Token);

            Console.WriteLine("You can pass child token to lined taske. if child is cancel , parent has no effect but if parent is cancelled , child will be also be cancelled.");



            var t1 = Task.Run<int>(() => Total(cts.Token), cts.Token);
            var t2 = Task.Run<int>(() => Total(childcts.Token), childcts.Token);
            Console.WriteLine("We pass cancellation , both to task and method. Task on will cancel the task and method will be use to take action on cancellation");

            //Thread.Sleep(10);
            cts.Cancel();

            try
            {
                Console.WriteLine(t1.Result);
                Console.WriteLine(t2.Result);
            }
            catch (AggregateException aex)
            {
                Console.WriteLine(aex.Message);
            }

            Console.WriteLine("Status of task :" + t1.Status);
            Console.WriteLine("Status of task :" + t2.Status);
        }


        static int Total(CancellationToken tok)
        {
            int sum = 0;
            Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Started");
            for (int count = 1; count <= 1000; count++)
            {
                if(tok.IsCancellationRequested)
                {
                    Console.WriteLine("Cancellation Requested");
                    tok.ThrowIfCancellationRequested();
                }
                sum = sum + count;
            }
            Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Completed");
            return sum;
        }

    }


}

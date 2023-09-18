using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Threading.AsyncProgramming
{
    public static class Tasks10AsyncAwaitWithException
    {
        public static async void runTask()
        {
            //Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Started");

            //await TaskWithoutReturn();

            //int result = await Total(10);
            //Console.WriteLine($"Async Await total is :- {result}");

            //Task.Delay(1000).Wait();
            //Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Completed");
        }

        //static Task<int> Total(int Max)
        //{
        //    //int sum = 0;
        //    //Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Started");
        //    //for (int count = 1; count <= Max; count++)
        //    //{
        //    //    sum = sum + count;
        //    //}
        //    //Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Completed");
        //    //return Task<int>.FromResult( sum);
        //}



        //static Task TaskWithoutReturn()
        //{
        //    //return Task.Run(() =>
        //    //{
        //    //    Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Started");
        //    //    Console.WriteLine("This is task that return Nothing");
        //    //    Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Completed");
        //    //});
           
        //}
    }


    }

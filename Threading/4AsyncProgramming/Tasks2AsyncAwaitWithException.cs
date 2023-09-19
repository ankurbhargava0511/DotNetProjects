using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Threading.AsyncProgramming
{
    public static class Tasks2AsyncAwaitWithException
    {
        public static async void runTask()
        {
            Console.WriteLine("Async Await Exception");
            await Catcher();

            Thread.Sleep(10000);
        }

       static async Task Catcher()
        {
            try 
            {
                Task thrower = Thrower();
                await thrower;
            } 
            catch (InvalidOperationException ex) 
            {
                Console.WriteLine("Exception from async await :" +ex.Message);
            }
        }

        static async Task Thrower()
        {
            await Task.Delay(10);
            throw new InvalidOperationException();
        }


        public static async void CatchMultipleExceptionfromAwait()
        {
            int[] numbers = { 0 };
            Task<int> t1 = Task.Run(() => 5 / numbers[0]);
            Task<int> t2 = Task.Run(() => numbers[1]);


            Task<int[]> allT = Task.WhenAll(t1, t2);

            try
            {
                await allT;
            }
            catch
            {
                foreach(var t in allT.Exception.InnerExceptions)
                {
                    Console.WriteLine($"{t.Message}");
                }
            }



        }


    }


    }

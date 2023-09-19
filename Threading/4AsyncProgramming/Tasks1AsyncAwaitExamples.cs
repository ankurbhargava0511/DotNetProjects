using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Threading.AsyncProgramming
{
    public static class Tasks1AsyncAwaitExamples
    {
        public static void runTask()
        {
            string u = "google.com";
            DumpWebPage(u);
            DumpWebPageAsync(u);
            DumpWebPageTaskAsync(u);

        }

        public static void runTaskOp()
        {
            Test1Async();
            TestAsyncWithMultiOperation();

        }



        static void DumpWebPage(string Uri)
        {
            WebClient wc = new WebClient();
            string page = wc.DownloadString(Uri);
            Console.WriteLine("Sync call");
            Console.WriteLine(page);
        }


        static async void DumpWebPageAsync(string Uri)
        {
            WebClient wc = new WebClient();
            string page = await wc.DownloadStringTaskAsync(Uri);
            Console.WriteLine("after await");
            Console.WriteLine(page);
        }


        static void DumpWebPageTaskAsync(string Uri)
        {
            WebClient wc = new WebClient();
            Task<string> task = wc.DownloadStringTaskAsync(Uri);

            task.ContinueWith(t=> {
                Console.WriteLine("With ContinueWith");
                Console.WriteLine(t.Result); 
            });
        }


        static async void Test1Async()
        {
            Task Op = operation();
            await Op;
        }

        static async void TestAsyncWithMultiOperation()
        {
            Task Op1 = operation1();
            Task Op2 = operation2();
            await Op1;
            await Op2;
        }

        static Task operation()
        {
            return Task.Delay(TimeSpan.FromMilliseconds(500));
        }


        static Task operation1()
        {
            return Task.Delay(TimeSpan.FromMilliseconds(1500));
        }


        static Task operation2()
        {
            return Task.Delay(TimeSpan.FromMilliseconds(500));
        }




    }


    }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Threading.AsyncProgramming
{
    public static class AsyncProgramming2EAP
    {
        public static void TestEAP()
        {


            Console.WriteLine("Main method Started");
            DownloadData();

            Console.WriteLine("Main method Completed");
            
        }

        public static void DownloadData()
        {
            var waitForAsync = new ManualResetEvent(false);
            var webClient = new WebClient();
            byte[] result = null;

            webClient.DownloadDataCompleted += (sender, args) =>
            {
                if (args.Error != null)
                {
                    throw args.Error;
                }
                else
                {
                    result = args.Result;
                }

                waitForAsync.Set();
            };

            webClient.DownloadDataAsync(new Uri("http://www.google.com/"));

            waitForAsync.WaitOne();
            Console.WriteLine(result.Length);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threading.AsyncProgramming
{
    public static class Task9NestedChildTasks
    {
        public static void runTask()
        {
            Task.Factory.StartNew(() =>
            {
                Task nested = Task.Factory.StartNew(() =>  
                 Console.WriteLine("Attaching to Parent"),TaskCreationOptions.AttachedToParent
                );
                
            }).Wait();

            Thread.Sleep(1000);
        }


    }


}

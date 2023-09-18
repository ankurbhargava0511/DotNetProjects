using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Threading.ParallelProgramming;

namespace Threading
{
    public static class ParallelProgrammingInGeneral
    {

        /* Type of Parallel programming Programing
         * Data Parallel: For, ForEach
         * Task Parallel: Invoke
         */

        

        public static void ExecuteTests()
        {

            //Console.WriteLine("Example of Parallel For Loop");
            //Parallel1For.runTask();

            //Console.WriteLine("Example of Parallel Option : 2 thread only, if you make it 1 thread it will be like for loop, -1 is like no option");
            //Parallel1Options.runTask();

            //Console.WriteLine("Example of Parallel Termination ");
            //Parallel1Termination.runTask();

            //Console.WriteLine("Example of Parallel ForEach Loop");
            //Parallel2ForEach.runTask();

            Console.WriteLine("Example of Parallel Invoke");
            Parallel3Invoke.runTask();


        }
    }
}

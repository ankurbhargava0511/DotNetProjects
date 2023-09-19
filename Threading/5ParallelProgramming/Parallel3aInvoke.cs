using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Threading.ParallelProgramming
{
    public static class Parallel3aInvoke
    {
        public static  void runTask()
        {
            Parallel.Invoke(RunLoop1, RunLoop2);

        }

        static void RunLoop1()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"Loop1:ThreadID:{Thread.CurrentThread.ManagedThreadId};Iteration:{i}");
                
            }
        }
        static void RunLoop2()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"Loop2:ThreadID:{Thread.CurrentThread.ManagedThreadId};Iteration:{i}");
                
            }
        }



    }


}

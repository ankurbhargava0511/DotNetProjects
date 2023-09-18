using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threading.AsyncProgramming;

namespace Threading
{
    public static class AsyncProgrammingInGeneral
    {

        /* There ate three type of Async Programing
         * APM (dotnet 1.1)-> Asynchronous Programming Model  Pattern -> Begin<MethodName> / End<MethodName> Example APM.txt
         * EAP() -> Event Based Asynchronous Programing Pattern -> MethodNameAsync , MethodNameCompleted, MethodNameAsyncCancel
         * TAP(4.0, 4.5) -> Task Based Asynchronous Programming Pattern ->Task , System.Threading.Task, Task is run on ThreadPool, TaskScheduler is reponsible for running a task
         * Async and Await (Dotnet 5) -> One or two await in async
         */

        

        public static void ExecuteTests()
        {

            // For APM Refer APM.txt

            //Console.WriteLine("Execute EAP");
            //AsyncProgramming2EAP.TestEAP();

            //Console.WriteLine("Run Task");
            //AsyncProgramming3TAP.runTask();


            //Console.WriteLine("Run Task Factory");
            //Task1FactoryExample.runTaskviaFactory();

            //Console.WriteLine("Run Task vis Run . This is recommended Method");
            //Task2RunExample.runTaskViaRun();



            //Console.WriteLine("Run Wait. To wait the main thread till child task is completed. similar to Join in thread");
            //Task3RunWaitExample.runTaskWait();

            //Console.WriteLine("Task with return value");
            //Task4ReturnTExample.runTaskReturn();

            //Console.WriteLine("Task with complex Return Type.");
            //Task5ReturnComplexTypeExample.runTaskReturn();



            //Console.WriteLine("Example of Task Continue With.");
            //Console.WriteLine("Once the task it finish continue with will execute next task and result of task one will be send to continuation task");
            //Task6ContinueWithSingleTaskExample.runTask();



            //Console.WriteLine("Example of Task Continue With Multiple task.");

            //Task7ContinueWithMultipleTaskExample.runTask();

            Console.WriteLine("Example of Task Continue with options. Faulted, completed, error, cancel.");
            Task8ContinueWithOverloadsExample.runTask();

            Console.WriteLine("Example of Async Await with return value and without return value");
            Task9AsyncAwait.runTask();

        }
    }
}

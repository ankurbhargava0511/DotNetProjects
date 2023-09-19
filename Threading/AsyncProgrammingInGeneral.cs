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


            //Console.WriteLine("Run Wait. To wait the main thread till all child task is completed. similar to Join in thread");
            //Task3RunWaitExample.runTaskWaitAll();



            //Console.WriteLine("Run Wait. To wait the main thread till any child task is completed. similar to Join in thread");
            //Task3RunWaitExample.runTaskWaitAny();



            //Console.WriteLine("Run Wait. When Any means when any task is completed , release the task and give me the thread. It will not block the current/ main thread");
            //Task3RunWaitExample.runTaskWhenAny();

            //Console.WriteLine("Task with return value");
            //Task4ReturnTExample.runTaskReturn();

            //Console.WriteLine("Task with complex Return Type.");
            //Task5ReturnComplexTypeExample.runTaskReturn();



            //Console.WriteLine("Example of Task Continue With.");
            //Console.WriteLine("Once the task it finish continue with will execute next task and result of task one will be send to continuation task");
            //Task6ContinueWithSingleTaskExample.runTask();



            //Console.WriteLine("Example of Task Continue With Multiple task.");

            //Task7ContinueWithMultipleTaskExample.runTask();

            //Console.WriteLine("Example of Task Continue with options. Faulted, completed, error, cancel.");
            //Task8ContinueWithOverloadsExample.runTask();

            //Console.WriteLine("Example of Task cancel.");
            //Task8ContinueWithOverloadsExampleWithCancel.runTask();
            //Console.WriteLine("Example of Task -> Child task cancel.");
            //Task8ContinueWithOverloadsExampleWithCancel.runTaskChildCanceled();
            //Console.WriteLine("Example of Task -> Parent task cancel.");
            //Task8ContinueWithOverloadsExampleWithCancel.runTaskParentCanceled();

            //Console.WriteLine("Example of Task Aggregation Exception.");
            //Task8ContinueWithOverloadsExampleWithException.runTask();

            //Console.WriteLine("Nested child Task -- childcreateoption.AttachedToParent");
            //Task9NestedChildTasks.runTask();


            //Console.WriteLine("Example of Async Await with return value and without return value");
            //Tasks1AsyncAwait.runTask();

            //Console.WriteLine("Example of Async Await and it comparison with task and sync");
            //Tasks1AsyncAwaitExamples.runTask();

            //Console.WriteLine("Example of Async Await or task and multiple operations");
            //Tasks1AsyncAwaitExamples.runTaskOp();

            //Console.WriteLine("Example of Async Await  - Return void, Task or Task of T");
            //Tasks1AsyncReturnType.runTask();

            //Console.WriteLine("Await doesnt return aggregated exception. you can catch them as needed it 1 task throw exception.");
            //Tasks2AsyncAwaitWithException.runTask();

            Console.WriteLine("Always await an awaitable method if possible, otherwise all exception be throe will be unobserve.");
            Tasks2AsyncAwaitWithException.CatchMultipleExceptionfromAwait();

            Console.Read();
        }
    }
}

namespace Threading.AsyncProgramming
{
    public static class Tasks1AsyncReturnType
    {
        public async static void runTask()
        {
           
            voidAsyncMethod();
            await AsyncMethodReturnTask();
            await AsyncMethodReturnTaskTypeT();

            

        }

     

        static async void voidAsyncMethod()
        {
            await operation();
            Console.WriteLine("async void method");
        }


        static async Task AsyncMethodReturnTask()
        {
           
            await operation();
            Console.WriteLine("async void return Task");
        }

        static async Task<int> AsyncMethodReturnTaskTypeT()
        {
            
            int i = 10;
            await operation();
            Console.WriteLine("async void return Task of int");
            return i;
        }


       
        static Task operation()
        {
            return Task.Delay(TimeSpan.FromMilliseconds(500));
        }



    }


    }

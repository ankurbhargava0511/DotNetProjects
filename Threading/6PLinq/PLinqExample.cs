namespace Threading.PLinq

{
    public static class PLinqExample    
    {
        public static  void runTask()
        {
            Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Started");


            var source = Enumerable.Range(100,500);

            var evennum = from num in source.AsParallel()
                          where num%2==0
                          select num;

            Console.WriteLine("Basic Example: {0} even number out of {1} total", evennum.Count(), source.Count());

            var evennum1 = from num in source.AsParallel().WithDegreeOfParallelism(2)
                          where num % 2 == 0
                          select num;

            Console.WriteLine("With Degree : {0} even number out of {1} total", evennum1.Count(), source.Count());

            Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Completed");

        }


    }


    }

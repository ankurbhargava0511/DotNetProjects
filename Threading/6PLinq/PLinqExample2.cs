namespace Threading.PLinq

{
    public static class PLinqExample2    
    {
        public static  void runTask()
        {
            IEnumerable<int> numbers = Enumerable.Range(3, 100000 - 3);

            var parallelQuery =
              from n in numbers.AsParallel()
              where Enumerable.Range(2, (int)Math.Sqrt(n)).All(i => n % i > 0)
              select n;

            int[] primes = parallelQuery.ToArray();

            primes.ToList().AsParallel()   // Wraps sequence in ParallelQuery<int>
                    .Where(n => n > 100)   // Outputs another ParallelQuery<int>
                    .AsParallel()          // Unnecessary - and inefficient!
                    .Select(n => n * n);

            // Pling doesnt guarantee order so if you want order add AsOrdered , but that will give performance hit

            parallelQuery =
                from n in numbers.AsParallel().AsOrdered()
                where Enumerable.Range(2, (int)Math.Sqrt(n)).All(i => n % i > 0)
                select n;

            // Suppose you want to get data from multiple site.

            var result = from site in new[]
            {
                "www.engineerspock.com",
                "www.udemy.com",
                "www.reddit.com",
                "www.facebook.com",
                "www.stackoverflow.com",
                "www.pluralsight.com"
            }
            .AsParallel().WithDegreeOfParallelism(6)
                         let p = new System.Net.NetworkInformation.Ping().Send(site)
                         select new
                         {
                             site,
                             Result = p.Status,
                             Time = p.RoundtripTime

                         };


        }


    }


    }

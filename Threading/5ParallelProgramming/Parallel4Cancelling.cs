namespace Threading.PLinq

{
    public static class Parallel4Cancelling
    {
        public static  void runTask()
        {
            List<CreditCard> cards = new List<CreditCard>()
            {
                new CreditCard(){Liabilities=1200, Id=1 },
                new CreditCard(){Liabilities=80, Id=2 },
                new CreditCard(){Liabilities=1100, Id=3 },
                new CreditCard(){Liabilities=100, Id=4 },
                new CreditCard(){Liabilities=3000, Id=5 },
                new CreditCard(){Liabilities=800, Id=6 },
                new CreditCard(){Liabilities=1450, Id=7 },
            };

            var cts = new CancellationTokenSource();

            var task = Task.Run(() =>
            {
                try
                {
                    cards.AsParallel().WithCancellation(cts.Token)
                    .ForAll(x =>
                    {
                        if (x.Liabilities > 1000)
                        {
                            x.Block(cts.Token);
                        }
                    });
                }
                catch (OperationCanceledException ex)
                {
                    Console.WriteLine("Cancelled!");
                }
            });

            Thread.Sleep(1500);
            Console.WriteLine("Cancelling");
            cts.Cancel();

            Console.Read();

        }



        public class CreditCard
        {
            public decimal Liabilities { get; set; }
            public int Id { get; set; }


            // In case of Parallel cancellation token whould not cancel the task , and it will lead to RanTocomplition, so we need to cancel Method as well
            public void Block(CancellationToken ct)
            {
                bool blocked = false;
                for (int i = 0; i < 3; i++)
                {
                    ct.ThrowIfCancellationRequested();

                    //connecting to a server
                    Console.WriteLine($"Connecting {Id}. Iteration:{i}");
                    Thread.Sleep(1000);

                    //idiotic condition
                    if (i == 3)
                    {
                        blocked = true;
                    }
                }
                if (blocked)
                    Console.WriteLine($"Blocked credit card. ID:{Id}");
            }
        }


    }


}

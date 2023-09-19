
using System.Collections.Concurrent;


namespace DotNetCollections._5ConcurrentCollections
{
    public static class Concurrent4Dictionary
    {
        public static void ConcurrentDictionaryDemo()
        {

            var controller = new StockController();
            TimeSpan workDay = new TimeSpan(0, 0, 1);

            Task t1 = Task.Run(() => new SalesManager("Bob").StartWork(controller, workDay));
            Task t2 = Task.Run(() => new SalesManager("Alice").StartWork(controller, workDay));
            Task t3 = Task.Run(() => new SalesManager("Rob").StartWork(controller, workDay));

            Task.WaitAll(t1, t2, t3);

            controller.DisplayStatus();

        }



    }
    public class RemoteBookStock
    {
        public static readonly List<string> Books =
            new List<string> { "Clean Code", "C# in Depth", "C++ for Beginners",
                    "Design Patterns in C#", "Marvel Heroes" };


    }

    public class StockController
    {
        readonly ConcurrentDictionary<string, int> _stock = new ConcurrentDictionary<string, int>();

        public void BuyBook(string item, int quantity)
        {
            _stock.AddOrUpdate(item, quantity, (key, oldValue) => oldValue + quantity);
        }

        public bool TryRemoveBookFromStock(string item)
        {
            if (_stock.TryRemove(item, out int val))
            {
                Console.WriteLine($"How much was removed:{val}");
                return true;
            }
            return false;
        }

        public bool TrySellBook(string item)
        {
            bool success = false;

            _stock.AddOrUpdate(item,
                itemName => { success = false; return 0; },
                (itemName, oldValue) =>
                {
                    if (oldValue == 0)
                    {
                        success = false;
                        return 0;
                    }
                    else
                    {
                        success = true;
                        return oldValue - 1;
                    }
                });
            return success;
        }
        public void DisplayStatus()
        {
            foreach (var pair in _stock)
            {
                Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
            }
        }

    }

    public class SalesManager
    {
        public string Name { get; }

        public SalesManager(string id)
        {
            Name = id;
        }

        public void StartWork(StockController stockController, TimeSpan workDay)
        {
            Random rand = new Random((int)DateTime.UtcNow.Ticks);
            DateTime start = DateTime.UtcNow;
            while (DateTime.UtcNow - start < workDay)
            {
                Thread.Sleep(rand.Next(50));
                int generatedNumber = rand.Next(10);
                bool shouldPurchase = generatedNumber % 2 == 0;
                bool shouldRemove = generatedNumber == 9;
                string itemName = RemoteBookStock.Books[rand.Next(RemoteBookStock.Books.Count)];

                if (shouldPurchase)
                {
                    int quantity = rand.Next(9) + 1;
                    stockController.BuyBook(itemName, quantity);
                    DisplayPurchase(itemName, quantity);
                }
                else if (shouldRemove)
                {
                    stockController.TryRemoveBookFromStock(itemName);
                    DisplayRemoveAttempt(itemName);
                }
                else
                {
                    bool success = stockController.TrySellBook(itemName);
                    DisplaySaleAttempt(success, itemName);
                }
            }
            Console.WriteLine("SalesManager {0} finished its work!", Name);
        }
        private void DisplayRemoveAttempt(string itemName)
        {
            Console.WriteLine("Thread {0} {1} removed {2}", Thread.CurrentThread.ManagedThreadId, Name, itemName);
        }

        public void DisplayPurchase(string itemName, int quantity)
        {
            Console.WriteLine("Thread {0}: {1} bought {2} of {3}", Thread.CurrentThread.ManagedThreadId, Name, quantity, itemName);
        }

        public void DisplaySaleAttempt(bool success, string itemName)
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine(success
                ? $"Thread {threadId}: {Name} sold {itemName}"
                : $"Thread {threadId}: {Name}: Out of stock of {itemName}");
        }

    }





}

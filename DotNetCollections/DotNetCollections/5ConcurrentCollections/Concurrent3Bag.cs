
using System.Collections.Concurrent;


namespace DotNetCollections._5ConcurrentCollections
{
    public static class Concurrent3Bag
    {
        public static void ConcurrentBagDemo()
        {
            var names = new ConcurrentBag<string>();
            names.Add("Bob");
            names.Add("Alice");
            names.Add("Rob");

            Console.WriteLine($"After enqueuing, count = {names.Count}");

            string item1; //= names.Dequeue();
            bool success = names.TryTake(out item1);
            if (success)
                Console.WriteLine("\nRemoving " + item1);
            else
                Console.WriteLine("queue was empty");

            string item2; //=names.Peek();
            success = names.TryPeek(out item2);
            if (success)
                Console.WriteLine("Peeking  " + item2);
            else
                Console.WriteLine("queue was empty");
            Console.WriteLine("Enumerating");
            PrintCollection.PrintOutCollection(names);

            Console.WriteLine("\nAfter enumerating, count = " + names.Count);
        }



    }




}

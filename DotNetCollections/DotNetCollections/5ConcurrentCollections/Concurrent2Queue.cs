
using System.Collections.Concurrent;


namespace DotNetCollections._5ConcurrentCollections
{
    public static class Concurrent2Queue
    {
        public static void ConcurrentQueueDemo()
        {
            var names = new ConcurrentQueue<string>();
            names.Enqueue("Bob");
            names.Enqueue("Alice");
            names.Enqueue("Rob");

            Console.WriteLine($"After enqueuing, count = {names.Count}");

            string item1; //= names.Dequeue();
            bool success = names.TryDequeue(out item1);
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

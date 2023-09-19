using System.Collections.Immutable;

namespace DotNetCollections._4ImmutableCollections
{
    public static class Immutable2Queue
    {
        public static void QueueDemo()
        {
            var queue = ImmutableQueue<int>.Empty;
            queue = queue.Enqueue(1);
            queue = queue.Enqueue(2);

            PrintCollection.PrintOutCollection(queue);

            int first = queue.Peek();
            Console.WriteLine($"Last item:{first}");

            queue = queue.Dequeue(out first);
            Console.WriteLine($"Last item:{first}; Last After Pop:{queue.Peek()}");
        }


    }




}

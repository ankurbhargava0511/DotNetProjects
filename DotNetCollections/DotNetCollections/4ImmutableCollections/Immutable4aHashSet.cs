using System.Collections.Immutable;

namespace DotNetCollections._4ImmutableCollections
{
    public static class Immutable4aHashSet
    {
        public static void SetsDemo()
        {
            var hashSet = ImmutableHashSet<int>.Empty;
            hashSet = hashSet.Add(5);
            hashSet = hashSet.Add(10);

            // Displays "5" and "10" in an unpredictable order.
            //(at least in multithreaded scenarios)
            PrintCollection.PrintOutCollection(hashSet);

            Console.WriteLine("Remove 5");
            hashSet = hashSet.Remove(5);

            PrintCollection.PrintOutCollection(hashSet);

            Console.WriteLine("--- ImmutableSortedSet Demo ---");


        }


    }




}

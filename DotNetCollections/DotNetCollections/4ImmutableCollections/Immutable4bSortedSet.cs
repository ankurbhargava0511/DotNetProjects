using System.Collections.Immutable;

namespace DotNetCollections._4ImmutableCollections
{
    public static class Immutable4bSortedSet
    {
        public static void SetsDemo()
        {

            var sortedSet = ImmutableSortedSet<int>.Empty;
            sortedSet = sortedSet.Add(10);
            sortedSet = sortedSet.Add(5);

            PrintCollection.PrintOutCollection(sortedSet);

            var smallest = sortedSet[0];
            Console.WriteLine($"Smallest Item:{smallest}");

            Console.WriteLine("Remove 5");
            sortedSet = sortedSet.Remove(5);

            PrintCollection.PrintOutCollection(sortedSet);
        }


    }




}

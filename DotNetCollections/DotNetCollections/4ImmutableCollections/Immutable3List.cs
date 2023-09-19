using System.Collections.Immutable;

namespace DotNetCollections._4ImmutableCollections
{
    public static class Immutable3List
    {
        public static void ListDemo()
        {
            var list = ImmutableList<int>.Empty;
            list = list.Add(2);
            list = list.Add(3);
            list = list.Add(4);
            list = list.Add(5);

            PrintCollection.PrintOutCollection(list);

            Console.WriteLine("Remove 4 and then RemoveAt index=2");
            list = list.Remove(4);
            list = list.RemoveAt(2);

            PrintCollection.PrintOutCollection(list);

            Console.WriteLine("Insert 1 at 0 and 4 at 3");
            list = list.Insert(0, 1);
            list = list.Insert(3, 4);

            PrintCollection.PrintOutCollection(list);
        }

    }




}

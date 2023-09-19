using System.Collections.Immutable;

namespace DotNetCollections._4ImmutableCollections
{
    public static class Immutable5SortedDictionary    {
        public static void ImmutableDictionaryDemo()
        {
            var dic = ImmutableSortedDictionary<int, string>.Empty;
            dic = dic.Add(4, "John");
            dic = dic.Add(3, "Alex");
            dic = dic.Add(2, "April");
            dic = dic.Add(1, "Test");

            // Displays in an predictable order.
            PrintCollection.IterateOverDictionary(dic);

            Console.WriteLine("Changing value of key 2 to Bob");
            dic = dic.SetItem(2, "Bob");

            PrintCollection.IterateOverDictionary(dic);

            var april = dic[3];
            Console.WriteLine($"Who is at key 3 = {april}");

            Console.WriteLine("Remove record where key = 2");
            dic = dic.Remove(2);

            PrintCollection.IterateOverDictionary(dic);


            Console.WriteLine("Adding record where key = 2 to test sort");
            dic = dic.Add(2,"TestValue");

            PrintCollection.IterateOverDictionary(dic);


        }

    }




}

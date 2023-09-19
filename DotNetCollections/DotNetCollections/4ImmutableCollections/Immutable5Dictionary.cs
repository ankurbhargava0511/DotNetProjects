using System.Collections.Immutable;

namespace DotNetCollections._4ImmutableCollections
{
    public static class Immutable5Dictionary    {
        public static void ImmutableDictionaryDemo()
        {
            var dic = ImmutableDictionary<int, string>.Empty;
            dic = dic.Add(1, "John");
            dic = dic.Add(2, "Alex");
            dic = dic.Add(3, "April");

            // Displays "1-John", "2-Alex", "3-April" in an unpredictable order.
            PrintCollection.IterateOverDictionary(dic);

            Console.WriteLine("Changing value of key 2 to Bob");
            dic = dic.SetItem(2, "Bob");

            PrintCollection.IterateOverDictionary(dic);

            var april = dic[3];
            Console.WriteLine($"Who is at key 3 = {april}");

            Console.WriteLine("Remove record where key = 2");
            dic = dic.Remove(2);

            PrintCollection.IterateOverDictionary(dic);
        }

    }




}

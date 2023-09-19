using System.Collections.Immutable;

namespace DotNetCollections
{
    public static class PrintCollection
    {

        public static void PrintOutCollection<T>(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }



        public static void IterateOverDictionary(ImmutableDictionary<int, string> dic)
        {
            foreach (var item in dic)
                Console.WriteLine(item.Key + "-" + item.Value);
        }


        public static void IterateOverDictionary(ImmutableSortedDictionary<int, string> dic)
        {
            foreach (var item in dic)
                Console.WriteLine(item.Key + "-" + item.Value);
        }

    }
}

using System.Collections.Immutable;
using System.Diagnostics;

namespace DotNetCollections._4ImmutableCollections
{
    public static class ImmutableCollectionsBuilder
    {

        private static readonly List<int> largeList = new List<int>(128);

        private static void GenerateList()
        {
            for (int i = 0; i < 100000; i++)
            {
                largeList.Add(i);
            }
        }


        public static void BuildImmutableCollectionbyForDemo()
        {
            Stopwatch sw = Stopwatch.StartNew();
            var builder = ImmutableList.CreateBuilder<int>();
            foreach (var item in largeList)
            {
                builder.Add(item);
            }
            ImmutableList<int> immutableList = builder.ToImmutable();

            sw.Stop();
            Console.WriteLine("Time using For: " + sw.ElapsedMilliseconds);
        }

        public static void BuildImmutableCollectionbyRangeDemo()
        {
            Stopwatch sw = Stopwatch.StartNew();
            var builder = ImmutableList.CreateBuilder<int>();
            builder.AddRange(largeList);
            ImmutableList<int> immutableList = builder.ToImmutable();

            sw.Stop();
            Console.WriteLine("Time using Range: " + sw.ElapsedMilliseconds);
        }


        public static void BuildImmutableCollectionbyToImmutableDemo()
        {
            Stopwatch sw = Stopwatch.StartNew();
            var list = largeList.ToImmutableList();

            sw.Stop();
            Console.WriteLine("Time using ToImmutable(recommended): " + sw.ElapsedMilliseconds);

        }


    }




}

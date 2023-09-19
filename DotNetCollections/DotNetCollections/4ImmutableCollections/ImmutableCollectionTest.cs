namespace DotNetCollections._4ImmutableCollections
{
    public static class ImmutableCollectionTest
    {
        public static void RunImmutableCollectionDemos()
        {
            //Console.WriteLine("Immutable Stack");
            //Immutable1Stack.StackDemo();

            //Console.WriteLine("Immutable Queue");
            //Immutable2Queue.QueueDemo();

            //Console.WriteLine("Immutable List . performance is logN" );
            //Immutable3List.ListDemo();

            //Console.WriteLine("Immutable Hash set");
            //Immutable4aHashSet.SetsDemo();

            //Console.WriteLine("Immutable Sorted set. Due to sorting there is a performance hit over hash set ");
            //Immutable4bSortedSet.SetsDemo();

            //Console.WriteLine("Immutable Dictonary");
            //Immutable5Dictionary.ImmutableDictionaryDemo();

            //Console.WriteLine("Immutable Sorted Dictonary");
            //Immutable5SortedDictionary.ImmutableDictionaryDemo();


            ImmutableCollectionsBuilder.BuildImmutableCollectionbyForDemo();
            ImmutableCollectionsBuilder.BuildImmutableCollectionbyRangeDemo();
            ImmutableCollectionsBuilder.BuildImmutableCollectionbyToImmutableDemo();



        }


    }
}

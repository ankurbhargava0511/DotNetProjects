namespace DotNetCollections._5ConcurrentCollections
{
    public static class ConcurrentCollectionTest
    {
        public static void RunConcurrentCollectionDemos()
        {
            //Console.WriteLine("Concurrent Stack- To mutate the collection can cause issue like while removing the item from empty thus we use tryXXXX");
            //Concurrent1Stack.ConcurrentStackDemo();
            //Console.WriteLine("Concurrent Queue- To mutate the collection can cause issue like while removing the item from empty thus we use tryXXXX");
            //Concurrent2Queue.ConcurrentQueueDemo();

            //Console.WriteLine("Concurrent Bag- To mutate the collection can cause issue like while removing the item from empty thus we use tryXXXX");
            //Concurrent3Bag.ConcurrentBagDemo();


            //Console.WriteLine("Concurrent Dictonary - AddOrUpdate, TryRemove(key, value, (key,value)=>oldvalue+value");
            //Concurrent4Dictionary.ConcurrentDictionaryDemo();

            Console.WriteLine("Blocking Collection , last parameter is the max number");
            Concurrent5ProducerConsumer_BlockingCollection.TestBlockingCollection();

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





        }


    }
}

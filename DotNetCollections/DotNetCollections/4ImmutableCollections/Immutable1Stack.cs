using System.Collections.Immutable;

namespace DotNetCollections._4ImmutableCollections
{
    public static class Immutable1Stack
    {
        public static void StackDemo()
        {
            var stack = ImmutableStack<int>.Empty;
            stack = stack.Push(1);
            stack = stack.Push(2);

            int last = stack.Peek();
            Console.WriteLine($"Last item:{last}");

            stack = stack.Pop(out last);

            Console.WriteLine($"Last item:{last}; Last after Pop:{stack.Peek()}");

        }
    }




}

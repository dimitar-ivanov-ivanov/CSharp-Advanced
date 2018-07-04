namespace StackFibonacci
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            Console.WriteLine(Execute(n));
        }

        private static long Execute(int n)
        {
            var stack = new Stack<long>();
            stack.Push(1);
            stack.Push(1);

            for (int i = 2; i < n; i++)
            {
                var first = stack.Pop();
                var second = stack.Pop();
                var third = first + second;
                stack.Push(first);
                stack.Push(third);
            }

            return stack.Pop();
        }
    }
}

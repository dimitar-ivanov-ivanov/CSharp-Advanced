namespace CalculateSequence
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

        private static string Execute(int n)
        {
            var list = new List<long>();
            var queue = new Queue<long>();
            queue.Enqueue(n);
            var length = 50;

            for (int i = 0; i < length; i++)
            {
                var top = queue.Dequeue();
                var first = top + 1;
                var second = 2 * top + 1;
                var third = top + 2;

                queue.Enqueue(first);
                queue.Enqueue(second);
                queue.Enqueue(third);
                list.Add(top);
            }

            return String.Join(" ", list);
        }
    }
}
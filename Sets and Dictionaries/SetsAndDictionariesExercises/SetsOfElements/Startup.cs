namespace SetsOfElements
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main(string[] args)
        {
            args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var n = int.Parse(args[0]);
            var m = int.Parse(args[1]);
            Console.WriteLine(Execute(n, m));
        }

        private static string Execute(int n, int m)
        {
            var firstNums = new HashSet<int>();
            var secondNums = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                firstNums.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < m; i++)
            {
                secondNums.Add(int.Parse(Console.ReadLine()));
            }

            firstNums.IntersectWith(secondNums);
            return string.Join(" ", firstNums);
        }
    }
}

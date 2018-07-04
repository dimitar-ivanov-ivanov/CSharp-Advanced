namespace ListOfPredicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var n = int.Parse(Console.ReadLine());
            var range = Enumerable.Range(1, n).ToArray();
            var dividors = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var res = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                Func<int, bool> func = p => i % p == 0;
                Func<int[], bool> allArrayAreDivisors = p => p.All(func);
                if (allArrayAreDivisors.Invoke(dividors))
                {
                    res.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", res));
        }
    }
}

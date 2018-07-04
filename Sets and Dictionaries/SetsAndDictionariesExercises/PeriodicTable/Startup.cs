namespace PeriodicTable
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            Console.WriteLine(Execute(n));
        }

        private static string Execute(int n)
        {
            var elements = new HashSet<string>();
            string[] args;
            for (int i = 0; i < n; i++)
            {
                args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < args.Length; j++)
                {
                    elements.Add(args[j]);
                }
            }

            return string.Join(" ", elements.OrderBy(e => e));
        }
    }
}
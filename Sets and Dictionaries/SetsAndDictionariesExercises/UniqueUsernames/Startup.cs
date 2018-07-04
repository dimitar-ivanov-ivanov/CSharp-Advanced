namespace UniqueUsernames
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
            var names = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                names.Add(Console.ReadLine());
            }

            return string.Join("\n", names);
        }
    }
}
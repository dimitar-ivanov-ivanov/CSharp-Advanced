namespace RageQuit
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var regex = new Regex($"(.*?)([0-9]+)");

            var matches = regex.Matches(Console.ReadLine().ToUpper());
            var builder = new StringBuilder();
            var hash = new HashSet<char>();

            foreach (Match m in matches)
            {
                var val = m.Groups[1].Value;
                var multiplier = int.Parse(m.Groups[2].Value);

                for (int i = 0; i < val.Length; i++)
                {
                    hash.Add(val[i]);
                }

                for (int i = 0; i < multiplier; i++)
                {
                    builder.Append(val.ToUpper());
                }
            }

            Console.WriteLine($"Unique symbols used: {hash.Count}");
            Console.WriteLine(builder.ToString());
        }
    }
}

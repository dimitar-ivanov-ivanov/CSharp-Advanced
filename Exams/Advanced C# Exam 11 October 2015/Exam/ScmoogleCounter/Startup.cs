namespace ScmoogleCounter
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
            var builder = new StringBuilder();
            var line = Console.ReadLine();
            while (line != "//END_OF_CODE")
            {
                builder.Append(line);
                line = Console.ReadLine();
            }

            var regex = new Regex("(int|double)\\s+([a-zA-Z]+)");
            var matches = regex.Matches(builder.ToString());
            var ints = new List<string>();
            var doubles = new List<string>();

            foreach (Match m in matches)
            {
                var val = m.Groups[1].Value;
                if (val == "int")
                {
                    ints.Add(m.Groups[2].Value);
                }
                else
                {
                    doubles.Add(m.Groups[2].Value);
                }
            }

            doubles.Sort();
            ints.Sort();

            if (doubles.Count != 0)
            {
                Console.WriteLine($"Doubles: {string.Join(", ", doubles)}");
            }
            else
            {
                Console.WriteLine("Doubles: None");
            }

            if (ints.Count != 0)
            {
                Console.WriteLine($"Ints: {string.Join(", ", ints)}");
            }
            else
            {
                Console.WriteLine("Ints: None");
            }
        }
    }
}

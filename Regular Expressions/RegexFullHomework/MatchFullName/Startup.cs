namespace MatchFullName
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Execute());
        }

        private static string Execute()
        {
            var regex = new Regex("[A-Z][a-z]+ [A-Z][a-z]+");
            var names = new List<string>();
            var line = Console.ReadLine();
            var output = new StringBuilder();

            while (line != "end")
            {
                names.Add(line);
                line = Console.ReadLine();
            }

            foreach (var name in names)
            {
                if (regex.IsMatch(name))
                {
                    output.AppendLine(name);
                }
            }

            return output.ToString();
        }
    }
}

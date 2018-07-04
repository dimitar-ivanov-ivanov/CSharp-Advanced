namespace PhoneNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Startup
    {
        private static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var builder = new StringBuilder();
            var line = Console.ReadLine();
            while (line != "END")
            {
                builder.Append(line);
                line = Console.ReadLine();
            }

            var text = builder.ToString();
            var phone = new Regex("(\\+?[0-9()\\/. -]+[0-9])");
            var clear = new Regex("(\\+?[()\\/. -]+)");
            var name = new Regex("[A-Z][a-z]+");

            var phoneMatches = phone.Matches(text);
            var nameMatches = name.Matches(text);

            var listPhones = new List<string>();
            var listNames = new List<string>();

            foreach (Match m in phoneMatches)
            {
                listPhones.Add(m.Value);
            }

            foreach (Match m in nameMatches)
            {
                listNames.Add(m.Value);
            }

            Console.WriteLine();
        }
    }
}

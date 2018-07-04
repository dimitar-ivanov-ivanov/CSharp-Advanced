namespace TextTransformer
{
    using System;
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
            var regex = new Regex("\\s+");
            var builder = new StringBuilder();
            var line = Console.ReadLine();

            while (line != "burp")
            {
                builder.Append(line);
                line = Console.ReadLine();
            }

            var text = builder.ToString();
            text = regex.Replace(text, " ");
            regex = new Regex("(?<special>[$%&'])([^$%&']+)(\\k<special>)");

            var matches = regex.Matches(text);
            builder = new StringBuilder();

            foreach (Match m in matches)
            {
                builder.Append(FindString(m.Groups["special"].Value, m.Groups[1].Value) + " ");
            }

            if (builder.Length > 0)
            {
                builder = builder.Remove(builder.Length - 1, 1);
            }

            return builder.ToString();
        }

        private static string FindString(string specialSymol, string value)
        {
            var weight = 0;
            var builder = new StringBuilder();

            switch (specialSymol)
            {
                case "$":
                    weight = 1;
                    break;
                case "%":
                    weight = 2;
                    break;
                case "&":
                    weight = 3;
                    break;
                case "'":
                    weight = 4;
                    break;
                default:
                    break;
            }

            for (int i = 0; i < value.Length; i++)
            {
                var newSymbol = (int)value[i];
                if (i % 2 == 0)
                {
                    newSymbol += weight;
                }
                else
                {
                    newSymbol -= weight;
                }

                builder.Append((char)newSymbol);
            }

            return builder.ToString();
        }
    }
}

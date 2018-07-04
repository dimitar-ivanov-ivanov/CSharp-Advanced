namespace SeriesOfLetters
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Execute());
        }

        private static string Execute()
        {
            var regex = new Regex("(.)\\1+");
            var line = Console.ReadLine();
            var matches = regex.Matches(line);

            foreach (Match m in matches)
            {
                var index = line.IndexOf(m.Value);
                line = line.Remove(index, m.Value.Length);
                line = line.Insert(index, m.Groups[1].Value);
            }

            return line;
        }
    }
}
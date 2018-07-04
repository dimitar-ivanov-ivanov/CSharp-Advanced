namespace SentenceExtractor
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
            var key = Console.ReadLine();
            var input = Console.ReadLine();
            var regex = new Regex($@"(( {key} |([A-Za-z0-9 -]+ {key} ))([A-Za-z0-9 -]+)*[!?.])");
            var matches = regex.Matches(input);
            var output = new StringBuilder();

            foreach (Match m in matches)
            {
                output.AppendLine(m.Value);
            }

            return output.ToString();
        }
    }
}
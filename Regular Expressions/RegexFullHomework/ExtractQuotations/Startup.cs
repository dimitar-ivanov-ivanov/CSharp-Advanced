namespace ExtractQuotations
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
            var input = Console.ReadLine();
            var regex = new Regex("(?<quote>'|\")(.+?)\\k<quote>");
            var matches = regex.Matches(input);
            var output = new StringBuilder();

            foreach (Match m in matches)
            {
                output.AppendLine(m.Groups[1].Value);
            }

            return output.ToString();
        }
    }
}

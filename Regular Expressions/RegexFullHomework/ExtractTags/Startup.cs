namespace ExtractTags
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
            var input = new StringBuilder();
            var output = new StringBuilder();
            var regex = new Regex("<(.+?)>");

            var line = Console.ReadLine();
            while (line != "END")
            {
                input.Append(line);
                line = Console.ReadLine();
            }

            var matches = regex.Matches(input.ToString());
            foreach (Match m in matches)
            {
                output.AppendLine(m.Value);
            }

            return output.ToString();
        }
    }
}
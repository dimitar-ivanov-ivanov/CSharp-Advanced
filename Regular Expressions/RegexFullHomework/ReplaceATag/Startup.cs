namespace ReplaceATag
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
            var regex = @"<a(\s+href\s*=\s*.+?)>(.*?)<\/a>";
            var line = Console.ReadLine();
            var input = new StringBuilder();

            while (line != "end")
            {
                input.Append(line);
                line = Console.ReadLine();
            }

            var fullText = input.ToString();
            var res = Regex.Replace(fullText, regex, "[URL$1]$2[/URL]");
            return res;
        }
    }
}
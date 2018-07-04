namespace ExtractHyperlinks
{
    using System;
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
            var regex = new Regex(@"<a.*?(?!<!"">)href\s*?=\s*?([""'])?(\S.*?)(?:>|class|\1)");
            var line = Console.ReadLine();
            var builder = new StringBuilder();

            while (line != "END")
            {
                builder.Append(line);
                line = Console.ReadLine();
            }

            var matches = regex.Matches(builder.ToString());
            foreach (Match m in matches)
            {
                var val = m.Groups[2].Value;
                Regex.Replace(val, "\\s+", " ");
                Console.WriteLine(val);
            }
        }
    }
}

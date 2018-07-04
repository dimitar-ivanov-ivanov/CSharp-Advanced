namespace Extract_Hyperlinks
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
            var regex = new Regex(@"<a.*?(?<!"">)href\s*?=\s*?([""'])?(\S.*?)(?:>|class|\1)");
            var builder = new StringBuilder();
            var input = new StringBuilder();

            while (true)
            {
                var line = Console.ReadLine();
                if (line == "END")
                {
                    break;
                }
                input.Append(line);
            }

            foreach (Match m in regex.Matches(input.ToString()))
            {
                var crop = m.Groups[2].Value;
                crop = Regex.Replace(crop, @"\s{2,}", " ");
                builder.AppendLine(crop);
            }

            return builder.ToString();
        }
    }
}

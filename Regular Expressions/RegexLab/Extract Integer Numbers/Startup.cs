namespace Extract_Integer_Numbers
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
            var regex = new Regex("\\d+");
            var builder = new StringBuilder();
            var matches = regex.Matches(input);

            foreach (Match m in matches)
            {
                builder.AppendLine(m.Value);
            }
            return builder.ToString();
        }
    }
}

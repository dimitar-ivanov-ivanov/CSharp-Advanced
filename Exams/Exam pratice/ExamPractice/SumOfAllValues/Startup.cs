namespace SumOfAllValues
{
    using System;
    using System.Globalization;
    using System.Text.RegularExpressions;
    using System.Threading;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Executed();
        }

        private static void Executed()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var keyRegex = new Regex("([a-zA-Z_]+)([0-9].*[0-9])([a-zA-Z_]+)");
            var line = Console.ReadLine();

            if (!keyRegex.IsMatch(line))
            {
                Console.WriteLine("<p>A key is missing</p>");
                return;
            }

            var match = keyRegex.Match(line);
            var start = match.Groups[1].Value;
            var end = match.Groups[3].Value;

            var textRegex = new Regex($"({start})(.*?)({end})");
            var digitRegex = new Regex($"[0-9][0-9.]*[0-9]");

            var text = Console.ReadLine();
            var matches = textRegex.Matches(text);
            decimal res = 0;

            foreach (Match m in matches)
            {
                decimal num = 0;
                var val = m.Groups[2].Value;
                if (decimal.TryParse(val, out num))
                {
                    if (digitRegex.IsMatch(val))
                    {
                        res += num;
                    }
                }
            }

            if (res == 0)
            {
                Console.WriteLine($"<p>The total value is: <em>nothing</em></p>");
            }
            else
            {
                Console.WriteLine($"<p>The total value is: <em>{res:f2}</em></p>");
            }
        }
    }
}

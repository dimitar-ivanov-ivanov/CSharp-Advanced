namespace CryptoBlockchain
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
            var regex = new Regex("([[{])(.*?)([]}])");
            var builder = new StringBuilder();
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                builder.Append(Console.ReadLine());
            }

            var input = builder.ToString();
            var matches = regex.Matches(input);
            var digitRegex = new Regex("\\d{3,}");
            var output = new StringBuilder();

            foreach (Match match in matches)
            {
                var firstBracket = match.Groups[1].Value;
                var lastBracket = match.Groups[3].Value;
                if ((firstBracket == "[" && lastBracket == "}") ||
                   (firstBracket == "{" && lastBracket == "]"))
                {
                    continue;
                }

                var cryptoBlock = match.Groups[2].Value;
                if (digitRegex.IsMatch(cryptoBlock))
                {
                    var digitMatch = digitRegex.Match(cryptoBlock).Value;
                    if (digitMatch.Length % 3 != 0)
                    {
                        continue;
                    }

                    for (int i = 0; i < digitMatch.Length; i += 3)
                    {
                        var str = digitMatch[i].ToString() + digitMatch[i + 1].ToString()
                            + digitMatch[i + 2].ToString();
                        var num = int.Parse(str);
                        num -= match.Length;
                        output.Append((char)num);
                    }
                }
            }

            Console.WriteLine(output);
        }
    }
}
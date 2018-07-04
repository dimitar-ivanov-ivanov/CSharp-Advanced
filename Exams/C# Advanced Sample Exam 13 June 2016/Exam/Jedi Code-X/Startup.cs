namespace Jedi_Code_X
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
            var n = int.Parse(Console.ReadLine());
            var builder = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                builder.Append(Console.ReadLine());
            }

            var first = Console.ReadLine();
            var second = Console.ReadLine();

            var regex = new Regex($"{first}([a-zA-Z0-9]" + "{" + $"{first.Length}" + "})");
            var firstPatternMatches = regex.Matches(builder.ToString());
            var firstPatternStr = new List<string>();

            regex = new Regex($"{second}([a-zA-Z0-9]" + "{" + $"{second.Length}" + "})");
            var secondPatternMatches = regex.Matches(builder.ToString());
            var secondPatternStr = new List<string>();

            foreach (Match m in firstPatternMatches)
            {
                firstPatternStr.Add(m.Groups[1].Value);
            }

            foreach (Match m in secondPatternMatches)
            {
                secondPatternStr.Add(m.Groups[1].Value);
            }

            var indices = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int i = 0, j = 0; i < firstPatternStr.Count && j < indices.Length; i++)
            {
                for (var k = j; k < indices.Length; k++, j++)
                {
                    if (indices[k] - 1 >= 0 && indices[k] - 1 < secondPatternStr.Count)
                    {
                        j++;
                        Console.WriteLine($"{firstPatternStr[i]} - {secondPatternStr[indices[k] - 1]}");
                        break;
                    }
                }
            }

        }
    }
}

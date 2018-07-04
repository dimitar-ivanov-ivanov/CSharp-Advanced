namespace SrabskoUnleashed
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
            Console.WriteLine(Execute());
        }

        private static string Execute()
        {
            var regex = new Regex(@"(([A-Za-z ]+){2}) @([A-Za-z ]+) (\d+) (\d+)");
            var concerts = new Dictionary<string, Dictionary<string, long>>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "End") break;

                if (!regex.IsMatch(input))
                {
                    continue;
                }

                var match = regex.Matches(input)[0];
                var singer = match.Groups[1].Value;
                var place = match.Groups[3].Value;
                var ticketsPrice = int.Parse(match.Groups[4].Value);
                var ticketsCount = int.Parse(match.Groups[5].Value);

                if (!concerts.ContainsKey(place))
                {
                    concerts.Add(place, new Dictionary<string, long>());
                }

                if (!concerts[place].ContainsKey(singer))
                {
                    concerts[place].Add(singer, 0);
                }

                concerts[place][singer] += ticketsPrice * ticketsCount;
            }

            var builder = new StringBuilder();

            foreach (var concert in concerts)
            {
                var singers = concert.Value
                    .OrderByDescending(x => x.Value)
                    .ToDictionary(x => x.Key, y => y.Value);

                builder.AppendLine(concert.Key);
                foreach (var singer in singers)
                {
                    builder.AppendLine($"#  {singer.Key} -> {singer.Value}");
                }
            }

            return builder.ToString();
        }
    }
}

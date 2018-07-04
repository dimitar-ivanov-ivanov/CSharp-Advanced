namespace SrabskoUnleashed
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Execute();
        }

        private static void Execute()
        {
            var regex = new Regex("(.*?) @(.*?) (\\d+) (\\d+)");
            var line = Console.ReadLine();
            var venues = new Dictionary<string, Dictionary<string, decimal>>();

            while (line != "End")
            {
                if (!regex.IsMatch(line))
                {
                    line = Console.ReadLine();
                    continue;
                }
                var match = regex.Match(line);

                var singer = match.Groups[1].Value;
                var venue = match.Groups[2].Value;
                decimal ticketsPrice = 0;
                decimal ticketsCount = 0;

                var args = singer.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (args.Length == 0 || args.Length > 3)
                {
                    line = Console.ReadLine();
                    continue;
                }

                args = venue.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (args.Length == 0 || args.Length > 3)
                {
                    line = Console.ReadLine();
                    continue;
                }

                if (!decimal.TryParse(match.Groups[3].Value, out ticketsPrice))
                {
                    line = Console.ReadLine();
                    continue;
                }

                if (!decimal.TryParse(match.Groups[4].Value, out ticketsCount))
                {
                    line = Console.ReadLine();
                    continue;
                }

                if (!venues.ContainsKey(venue))
                {
                    venues.Add(venue, new Dictionary<string, decimal>());
                }
                if (!venues[venue].ContainsKey(singer))
                {
                    venues[venue].Add(singer, 0);
                }

                venues[venue][singer] += ticketsCount * ticketsPrice;
                line = Console.ReadLine();
            }

            Print(venues);
        }

        private static void Print(Dictionary<string, Dictionary<string, decimal>> venues)
        {
            foreach (var venue in venues)
            {
                Console.WriteLine(venue.Key);
                var singers = venue.Value.OrderByDescending(x => x.Value)
                    .ToDictionary(x => x.Key, x => x.Value);

                foreach (var singer in singers)
                {
                    Console.WriteLine($"#  {singer.Key} -> {singer.Value}");
                }
            }
        }
    }
}

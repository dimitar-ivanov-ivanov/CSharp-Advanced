namespace Events
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
            var regex = new Regex(@"#([a-zA-Z]+):\s*@([a-zA-Z]+)\s*(\d+):(\d+)");
            var dict = new Dictionary<string, SortedDictionary<string, List<DateTime>>>();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();
                if (!regex.IsMatch(line))
                {
                    continue;
                }

                var match = regex.Match(line);
                var personName = match.Groups[1].Value;
                var locationName = match.Groups[2].Value;
                var hour = int.Parse(match.Groups[3].Value);
                var minutes = int.Parse(match.Groups[4].Value);

                if (!(hour >= 0 && hour <= 23 && minutes >= 0 && minutes <= 59))
                {
                    continue;
                }

                if (!dict.ContainsKey(locationName))
                {
                    dict.Add(locationName, new SortedDictionary<string, List<DateTime>>());
                }

                if (!dict[locationName].ContainsKey(personName))
                {
                    dict[locationName].Add(personName, new List<DateTime>());
                }

                var timeSpan = new DateTime(2000, 12, 12, hour, minutes, 0);
                dict[locationName][personName].Add(timeSpan);
            }

            var locations = Console.ReadLine()
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .OrderBy(x => x)
                .ToArray();


            foreach (var location in locations)
            {
                if (!dict.ContainsKey(location))
                {
                    continue;
                }

                Console.WriteLine($"{location}:");
                var count = 1;

                foreach (var person in dict[location])
                {
                    var personName = person.Key;
                    var times = person.Value.OrderBy(x => x)
                        .Select(x => x.ToString("HH:mm"))
                        .ToArray();

                    Console.WriteLine($"{count++}. {personName} -> {string.Join(", ", times)}");
                }
            }
        }
    }
}

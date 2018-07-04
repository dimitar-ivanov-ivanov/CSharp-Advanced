namespace OlympicsAreComing
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
            var teams = new Dictionary<string, HashSet<string>>();
            var teamWins = new Dictionary<string, int>();

            var regex = new Regex("\\s+");
            var args = Console.ReadLine().Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

            while (args[0] != "report")
            {
                var name = regex.Replace(args[0], " ").Trim();
                var country = regex.Replace(args[1], " ").Trim();

                if (!teams.ContainsKey(country))
                {
                    teams.Add(country, new HashSet<string>());
                    teamWins.Add(country, 0);
                }

                teamWins[country]++;
                teams[country].Add(name);
                args = Console.ReadLine().Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            }

            teamWins = teamWins.OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var team in teamWins)
            {
                Console.WriteLine($"{team.Key} ({teams[team.Key].Count} participants): {team.Value} wins");
            }
        }
    }
}

namespace ChampionsLeague
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var teamWins = new Dictionary<string, int>();
            var teamOpponents = new Dictionary<string, SortedSet<string>>();

            var args = Console.ReadLine().Split(new[] { '|', ':' }, StringSplitOptions.RemoveEmptyEntries);

            while (args[0] != "stop")
            {
                var team1 = args[0].Trim();
                var team2 = args[1].Trim();
                var firstTeamGoalsHome = int.Parse(args[2]);
                var secondTeamGoalsAway = int.Parse(args[3]);
                var firstTeamGoalsAway = int.Parse(args[5]);
                var secondTeamGoalsHome = int.Parse(args[4]);

                var totalGoalsFirstTeam = firstTeamGoalsAway + firstTeamGoalsHome;
                var totalGoalsSecondTeam = secondTeamGoalsHome + secondTeamGoalsAway;

                if (!teamWins.ContainsKey(team1))
                {
                    teamWins.Add(team1, 0);
                    teamOpponents.Add(team1, new SortedSet<string>());
                }

                if (!teamWins.ContainsKey(team2))
                {
                    teamWins.Add(team2, 0);
                    teamOpponents.Add(team2, new SortedSet<string>());
                }

                teamOpponents[team1].Add(team2);
                teamOpponents[team2].Add(team1);

                if (totalGoalsFirstTeam > totalGoalsSecondTeam)
                {
                    teamWins[team1]++;
                }
                else if (totalGoalsFirstTeam < totalGoalsSecondTeam)
                {
                    teamWins[team2]++;
                }
                else
                {
                    if (firstTeamGoalsAway > secondTeamGoalsAway)
                    {
                        teamWins[team1]++;
                    }
                    else if (firstTeamGoalsAway < secondTeamGoalsAway)
                    {
                        teamWins[team2]++;
                    }
                }

                args = Console.ReadLine().Split(new[] { '|', ':' }, StringSplitOptions.RemoveEmptyEntries);
            }

            teamWins = teamWins.OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var team in teamWins)
            {
                Console.WriteLine(team.Key);
                Console.WriteLine($"- Wins: {team.Value}");
                Console.WriteLine($"- Opponents: {string.Join(", ", teamOpponents[team.Key])}");
            }
        }
    }
}

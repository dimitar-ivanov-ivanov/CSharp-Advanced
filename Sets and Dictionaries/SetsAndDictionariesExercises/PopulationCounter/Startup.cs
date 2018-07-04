namespace PopulationCounter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Execute());
        }

        private static string Execute()
        {
            var args = Console.ReadLine().Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            var res = new StringBuilder();
            var dict = new Dictionary<string, Dictionary<string, long>>();

            while (args[0] != "report")
            {
                var city = args[0];
                var country = args[1];
                var population = long.Parse(args[2]);

                if (!dict.ContainsKey(country))
                {
                    dict.Add(country, new Dictionary<string, long>());
                }

                if (!dict[country].ContainsKey(city))
                {
                    dict[country].Add(city, 0);
                }

                dict[country][city] += population;
                args = Console.ReadLine().Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            }

            dict = dict.OrderByDescending(d => d.Value.Values
            .Sum(c => c))
            .ToDictionary(x => x.Key, x => x.Value);

            foreach (var country in dict)
            {
                var population = country.Value.Values.Sum(c => c);
                res.AppendLine($"{country.Key} (total population: " +
                    $"{population})");

                foreach (var city in country.Value.OrderByDescending(c => c.Value))
                {
                    res.AppendLine($"=>{city.Key}: {city.Value}");
                }
            }

            return res.ToString();
        }
    }
}

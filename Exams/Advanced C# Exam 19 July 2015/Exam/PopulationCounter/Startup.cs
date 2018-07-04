namespace PopulationCounter
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
            var countries = new Dictionary<string, Dictionary<string, long>>();
            var args = Console.ReadLine().Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

            while (args[0] != "report")
            {
                var city = args[0];
                var country = args[1];
                var population = long.Parse(args[2]);

                if (!countries.ContainsKey(country))
                {
                    countries.Add(country, new Dictionary<string, long>());
                }

                if (!countries[country].ContainsKey(city))
                {
                    countries[country].Add(city, 0);
                }

                countries[country][city] += population;

                args = Console.ReadLine().Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            }

            countries = countries.OrderByDescending(x => x.Value.Values.Sum())
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var country in countries)
            {
                Console.WriteLine($"{country.Key} (total population: {country.Value.Values.Sum()})");

                foreach (var city in country.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"=>{city.Key}: {city.Value}");
                }
            }
        }
    }
}

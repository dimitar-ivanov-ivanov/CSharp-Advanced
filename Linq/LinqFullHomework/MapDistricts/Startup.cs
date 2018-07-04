namespace MapDistricts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Execute());
        }

        private static string Execute()
        {
            var dict = new Dictionary<string, List<long>>();
            var arr = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x =>
                {
                    return SplitAndAdd(dict, x);
                })
                    .ToArray();

            var minPopulation = long.Parse(Console.ReadLine());
            var res = dict.Where(x => x.Value.Sum() > minPopulation)
                .OrderByDescending(x => x.Value.Sum())
                .Select(x => new
                {
                    output = $"{x.Key}: {string.Join(" ", x.Value.OrderByDescending(val => val).Take(5))}"
                })
                .ToArray();

            return string.Join("\n", res.Select(x => x.output));
        }

        private static string SplitAndAdd(Dictionary<string, List<long>> dict, string x)
        {
            var args = x.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            var city = args[0];
            var pop = long.Parse(args[1]);

            if (!dict.ContainsKey(city))
            {
                dict.Add(city, new List<long>());
            }

            dict[city].Add(pop);
            return "";
        }
    }
}

namespace CubicAssault
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
            var regions = new Dictionary<string, Dictionary<string, int>>();
            var args = Console.ReadLine().Split(new[] { '>', '-' }, StringSplitOptions.RemoveEmptyEntries);

            while (!string.Join(" ", args).Equals("Count em all"))
            {
                var region = args[0].Trim();
                var type = args[1].Trim();
                var quantity = int.Parse(args[2].Trim());

                if (!regions.ContainsKey(region))
                {
                    regions.Add(region, new Dictionary<string, int>());
                    regions[region].Add("Red", 0);
                    regions[region].Add("Black", 0);
                    regions[region].Add("Green", 0);
                }

                regions[region][type] += quantity;
                if (regions[region]["Green"] >= 1000000)
                {
                    regions[region]["Red"] += regions[region]["Green"] / 1000000;
                    regions[region]["Green"] %= 1000000;
                }

                if (regions[region]["Red"] >= 1000000)
                {
                    regions[region]["Black"] += regions[region]["Red"] / 1000000;
                    regions[region]["Red"] %= 1000000;
                }

                args = Console.ReadLine().Split(new[] { '>', '-' }, StringSplitOptions.RemoveEmptyEntries);
            }

            regions = regions
                    .OrderByDescending(x => x.Value
                    .Where(k => k.Key == "Black").FirstOrDefault().Value)
                    .ThenBy(x => x.Key.Length)
                    .ThenBy(x => x.Key)
                    .ToDictionary(x => x.Key, x => x.Value);


            foreach (var reg in regions)
            {
                Console.WriteLine(reg.Key);
                foreach (var type in reg.Value
                    .OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"-> {type.Key} : {type.Value}");
                }
            }
        }
    }
}
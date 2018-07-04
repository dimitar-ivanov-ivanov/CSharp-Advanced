namespace GreedyTimes
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
            var currencies = new Dictionary<string, Dictionary<string, long>>();
            var currenciesSum = new Dictionary<string, long>();
            long cash = 0;
            long gem = 0;
            long gold = 0;

            var capacity = long.Parse(Console.ReadLine());
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length - 1; i += 2)
            {
                var first = input[i];
                var lower = first.ToLower();
                var upper = first.ToUpper();
                var val = long.Parse(input[i + 1]);

                if (first.Length == 3)
                {
                    if (cash + val <= gem)
                    {
                        if (!currencies.ContainsKey("Cash"))
                        {
                            currencies.Add("Cash", new Dictionary<string, long>());
                            currenciesSum.Add("Cash", 0);
                        }

                        if (!currencies["Cash"].ContainsKey(first) ||
                            !currencies["Cash"].ContainsKey(lower) ||
                            !currencies["Cash"].ContainsKey(upper))
                        {
                            currencies["Cash"].Add(first, 0);
                        }

                        currencies["Cash"][first] += val;
                        currenciesSum["Cash"] += val;
                        cash += val;
                    }
                }
                else if (first.EndsWith("gem") || first.EndsWith("Gem"))
                {
                    if (gem + val <= gold)
                    {
                        if (!currencies.ContainsKey("Gem"))
                        {
                            currencies.Add("Gem", new Dictionary<string, long>());
                            currenciesSum.Add("Gem", 0);
                        }

                        if (!currencies["Gem"].ContainsKey(first))
                        {
                            currencies["Gem"].Add(first, 0);
                        }

                        currencies["Gem"][first] += val;
                        currenciesSum["Gem"] += val;
                        gem += val;
                    }
                }
                else if (first == "Gold")
                {
                    if (!currencies.ContainsKey("Gold"))
                    {
                        currencies.Add("Gold", new Dictionary<string, long>());
                        currencies["Gold"].Add("Gold", 0);
                        currenciesSum.Add("Gold", 0);
                    }

                    currencies["Gold"]["Gold"] += val;
                    currenciesSum["Gold"] += val;
                    gold += val;
                }
            }

            currenciesSum = currenciesSum.OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, y => y.Value);

            foreach (var item in currenciesSum.Keys)
            {
                var items = currencies[item].OrderByDescending(x => x.Key)
                    .ThenBy(x => x.Value)
                    .ToDictionary(x => x.Key, y => y.Value);

                Console.WriteLine($"<{item}> ${currenciesSum[item]}");

                foreach (var type in items)
                {
                    Console.WriteLine($"##{type.Key} - {type.Value}");
                }
            }
        }
    }
}
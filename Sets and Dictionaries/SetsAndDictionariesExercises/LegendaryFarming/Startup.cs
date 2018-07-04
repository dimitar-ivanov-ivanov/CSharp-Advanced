namespace LegendaryFarming
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
            string[] args;
            var keyItems = new Dictionary<string, int>();
            var junkItems = new Dictionary<string, int>();
            keyItems.Add("motes", 0);
            keyItems.Add("fragments", 0);
            keyItems.Add("shards", 0);

            while (true)
            {
                args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < args.Length - 1; i += 2)
                {
                    var amount = int.Parse(args[i]);
                    var item = args[i + 1].ToLower();

                    if (keyItems.ContainsKey(item))
                    {
                        keyItems[item] += amount;
                        if (keyItems[item] >= 250)
                        {
                            keyItems[item] -= 250;
                            return Print(item, keyItems, junkItems);
                        }
                    }
                    else
                    {
                        if (!junkItems.ContainsKey(item))
                        {
                            junkItems.Add(item, 0);
                        }
                        junkItems[item] += amount;
                    }
                }
            }
        }

        private static string Print(string itemName, Dictionary<string, int> keyItems, Dictionary<string, int> junkItems)
        {
            var builder = new StringBuilder();
            var reward = "";

            if (itemName == "fragments")
            {
                reward = "Valanyr";
            }
            else if (itemName == "motes")
            {
                reward = "Dragonwrath";
            }
            else
            {
                reward = "Shadowmourne";
            }

            builder.AppendLine($"{reward} obtained!");
            keyItems = keyItems.OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            junkItems = junkItems.OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            builder.AppendLine(string.Join("\n", keyItems.Select(x => $"{x.Key}: {x.Value}")));
            builder.AppendLine(string.Join("\n", junkItems.Select(x => $"{x.Key}: {x.Value}")));

            return builder.ToString();
        }
    }
}

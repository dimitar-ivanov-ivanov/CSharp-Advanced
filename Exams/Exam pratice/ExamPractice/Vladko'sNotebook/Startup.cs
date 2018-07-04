namespace Vladko_sNotebook
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
            var colours = new Dictionary<string, Colour>();
            var args = Console.ReadLine().Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

            while (args[0] != "END")
            {
                var color = args[0];
                var attribute = args[1];
                var val = args[2];

                if (!colours.ContainsKey(color))
                {
                    colours.Add(color, new Colour());
                }

                switch (attribute)
                {
                    case "name":
                        colours[color].Name = val;
                        break;
                    case "win":
                        colours[color].Wins++;
                        colours[color].Opponents.Add(val);
                        break;
                    case "loss":
                        colours[color].Loses++;
                        colours[color].Opponents.Add(val);
                        break;
                    case "age":
                        colours[color].Age = int.Parse(val);
                        break;
                    default:
                        break;
                }

                args = Console.ReadLine().Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            }

            colours = colours
                .Where(x => x.Value.Age != -1 && x.Value.Name != null)
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            if (colours.Count == 0)
            {
                Console.WriteLine("No data recovered.");
                return;
            }

            foreach (var c in colours)
            {
                var arr = c.Value.Opponents.ToArray();
                Array.Sort(arr, StringComparer.Ordinal);
                Console.WriteLine($"Color: {c.Key}");
                Console.WriteLine($"-age: {c.Value.Age}");
                Console.WriteLine($"-name: {c.Value.Name}");

                var oppStr = arr.Length == 0 ? "(empty)" : string.Join(", ", arr);
                Console.WriteLine($"-opponents: {oppStr}");
                Console.WriteLine($"-rank: {c.Value.GetRank()}");
            }
        }
    }

    public class Colour
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public List<string> Opponents { get; set; }
        public int Wins { get; set; }
        public int Loses { get; set; }

        public Colour()
        {
            this.Age = -1;
            this.Name = null;
            this.Opponents = new List<string>();
        }

        public string GetRank()
        {
            var rank = (Wins + 1) / (decimal)(Loses + 1);
            return $"{rank:f2}";
        }
    }
}

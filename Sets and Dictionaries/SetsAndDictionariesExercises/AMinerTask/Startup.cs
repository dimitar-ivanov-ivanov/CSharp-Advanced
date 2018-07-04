namespace AMinerTask
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Execute());
        }

        private static string Execute()
        {
            var name = Console.ReadLine();
            var quantity = long.Parse(Console.ReadLine());
            var miners = new Dictionary<string, long>();
            var res = new StringBuilder();

            while (name != "Stop" && name != "stop")
            {
                if (!miners.ContainsKey(name))
                {
                    miners.Add(name, 0);
                }

                miners[name] += quantity;

                name = Console.ReadLine();
                if (name == "stop" || name == "Stop")
                {
                    break;
                }
                quantity = long.Parse(Console.ReadLine());
            }

            foreach (var miner in miners)
            {
                res.AppendLine($"{miner.Key} -> {miner.Value}");
            }

            return res.ToString();
        }
    }
}

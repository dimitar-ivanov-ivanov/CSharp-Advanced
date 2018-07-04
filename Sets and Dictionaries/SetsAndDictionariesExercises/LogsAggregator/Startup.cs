namespace LogsAggregator
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            Console.WriteLine(Execute(n));
        }

        private static string Execute(int n)
        {
            var res = new StringBuilder();
            var logs = new SortedDictionary<string, SortedSet<string>>();
            var logsDuration = new Dictionary<string, long>();


            for (int i = 0; i < n; i++)
            {
                var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var ip = args[0];
                var name = args[1];
                var duration = int.Parse(args[2]);

                if (!logs.ContainsKey(name))
                {
                    logs.Add(name, new SortedSet<string>());
                    logsDuration.Add(name, 0);
                }

                logs[name].Add(ip);
                logsDuration[name] += duration;
            }

            foreach (var log in logs)
            {
                res.AppendLine($"{log.Key}: {logsDuration[log.Key]} " +
                    $"[{string.Join(", ", log.Value)}]");
            }

            return res.ToString();
        }
    }
}
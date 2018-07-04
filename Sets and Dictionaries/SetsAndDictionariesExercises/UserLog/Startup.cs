namespace UserLog
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
            var res = new StringBuilder();
            var log = new Dictionary<string, Dictionary<string, int>>();
            var args = Console.ReadLine().Split(new[] { ' ', '=' }, StringSplitOptions.RemoveEmptyEntries);

            while (args[0] != "end")
            {
                var ip = args[1];
                var name = args[5];

                if (!log.ContainsKey(name))
                {
                    log.Add(name, new Dictionary<string, int>());
                }

                if (!log[name].ContainsKey(ip))
                {
                    log[name].Add(ip, 0);
                }

                log[name][ip]++;
                args = Console.ReadLine().Split(new[] { ' ', '=' }, StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var l in log.OrderBy(l => l.Key))
            {
                res.AppendLine($"{l.Key}: ");
                foreach (var ip in l.Value)
                {
                    res.Append($"{ip.Key} => {ip.Value}, ");
                }

                res = res.Remove(res.Length - 2, 2);
                res.Append('.');
                res.AppendLine();
            }

            return res.ToString();
        }
    }
}

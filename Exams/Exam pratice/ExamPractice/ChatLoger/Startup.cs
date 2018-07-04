namespace ChatLoger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var dict = new Dictionary<string, DateTime>();
            var startDate = DateTime.Parse(Console.ReadLine());

            var args = Console.ReadLine().Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            while (args[0] != "END")
            {
                var message = args[0].Trim();
                var time = DateTime.Parse(args[1].Trim());

                if (!dict.ContainsKey(message))
                {
                    dict.Add(message, time);
                }

                args = Console.ReadLine().Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            }

            dict = dict.OrderBy(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);

            var resTime = new DateTime();

            foreach (var m in dict)
            {
                resTime = m.Value;
                Console.WriteLine($"<div>{SecurityElement.Escape(m.Key)}</div>");
            }

            FindDiffernceInDate(startDate, resTime);
        }

        private static void FindDiffernceInDate(DateTime date1, DateTime date2)
        {
            var seconds = (date1 - date2).TotalSeconds;
            var days = (date1 - date2).TotalDays;
            var hours = (date1 - date2).TotalHours;
            var minutes = (date1 - date2).TotalMinutes;

            if (days > 1)
            {
                Console.WriteLine($"<p>Last active: <time>{date2:dd-mm-YYYY}</time></p>.");
                return;
            }

            if (seconds < 60)
            {
                Console.WriteLine($"<p>Last active: <time>a few moments ago</time></p>.");
                return;
            }

            if (minutes < 60)
            {
                Console.WriteLine($"<p>Last active: <time>{minutes} minute(s) ago</time></p>.");
                return;
            }

            if (days <= 1)
            {
                Console.WriteLine($"<p>Last active: <time>yesterday</time></p>.");
                return;
            }

            if (hours < 24)
            {
                Console.WriteLine($"<p>Last active: <time>{hours} hour(s) ago</time></p>.");
                return;
            }
        }
    }
}

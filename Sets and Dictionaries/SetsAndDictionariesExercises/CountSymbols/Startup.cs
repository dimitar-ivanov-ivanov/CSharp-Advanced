namespace CountSymbols
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var str = Console.ReadLine();
            Console.WriteLine(Execute(str));
        }

        private static string Execute(string str)
        {
            var dict = new Dictionary<char, int>();

            for (int i = 0; i < str.Length; i++)
            {
                if (!dict.ContainsKey(str[i]))
                {
                    dict.Add(str[i], 0);
                }
                dict[str[i]]++;
            }

            var res = new StringBuilder();
            foreach (var ch in dict.OrderBy(c => c.Key))
            {
                res.AppendLine($"{ch.Key}: {ch.Value} time/s");
            }

            return res.ToString();
        }
    }
}

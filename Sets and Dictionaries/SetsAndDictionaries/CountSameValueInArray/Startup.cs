namespace CountSameValueInArray
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    using System.Threading;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Execute());
        }

        private static string Execute()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var dict = new SortedDictionary<Double, int>();
            var args = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < args.Length; i++)
            {
                var num = double.Parse(args[i]);
                if (!dict.ContainsKey(num))
                {
                    dict.Add(num, 0);
                }
                dict[num]++;
            }


            var res = new StringBuilder();
            foreach (var num in dict)
            {
                res.AppendLine($"{num.Key} - {num.Value} times");
            }

            return res.ToString().Trim();
        }
    }
}
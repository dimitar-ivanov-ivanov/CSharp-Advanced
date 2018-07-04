namespace BiggestTableRow
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var begin = Console.ReadLine();
            double max = 0;
            var output = new List<string>();
            var args = Console.ReadLine().Split(new[] { '<', '>', '/' }, StringSplitOptions.RemoveEmptyEntries);

            while (args[0] != "table")
            {
                var digits = new List<string>();
                double sum = 0;

                for (int i = 0; i < args.Length; i++)
                {
                    args[i] = args[i].Replace("td", "");
                    double val = 0;

                    if (double.TryParse(args[i], out val))
                    {
                        sum += val;
                        digits.Add(args[i]);
                    }
                }

                if (max < sum)
                {
                    max = sum;
                    output = digits.ToList();
                }

                args = Console.ReadLine().Split(new[] { '<', '>', '/' }, StringSplitOptions.RemoveEmptyEntries);
            }

            if (output.Count == 0)
            {
                Console.WriteLine("no data");
            }
            else
            {
                Console.WriteLine($"{max} = {string.Join(" + ", output)}");
            }
        }
    }
}

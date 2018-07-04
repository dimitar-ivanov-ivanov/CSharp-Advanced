namespace AcademyGraduation
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading;

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
            var dict = new SortedDictionary<string, double>();
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            for (int i = 0; i < n; i++)
            {
                var name = Console.ReadLine();
                var nums = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse).ToArray();

                dict.Add(name, nums.Average());
            }

            foreach (var d in dict)
            {
                res.AppendLine($"{d.Key} is graduated with {d.Value}");
            }

            return res.ToString().Trim();
        }
    }
}
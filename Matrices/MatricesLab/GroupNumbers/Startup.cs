namespace GroupNumbers
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
            var res = new StringBuilder();
            var matrix = new Dictionary<int, List<int>>();
            matrix.Add(0, new List<int>());
            matrix.Add(1, new List<int>());
            matrix.Add(2, new List<int>());

            var args = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < args.Length; i++)
            {
                var num = int.Parse(args[i]);
                var remainder = Math.Abs(num % 3);
                matrix[remainder].Add(num);
            }

            foreach (var num in matrix)
            {
                res.AppendLine(string.Join(" ", num.Value));
            }

            return res.ToString();
        }
    }
}

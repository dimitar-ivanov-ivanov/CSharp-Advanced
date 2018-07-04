namespace LegoBlocks
{
    using System;
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
            var n = int.Parse(Console.ReadLine());
            var a = new int[n][];
            var b = new int[n][];
            var builder = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                a[i] = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
            }

            for (int i = 0; i < n; i++)
            {
                b[i] = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                Array.Reverse(b[i]);
            }

            var firstSumColumn = a[0].Length + b[0].Length;
            var matricesMatch = true;
            var totalCells = 0;

            for (int i = 0; i < n; i++)
            {
                totalCells += a[i].Length + b[i].Length;
                if (firstSumColumn != a[i].Length + b[i].Length)
                {
                    matricesMatch = false;
                }
            }

            if (!matricesMatch)
            {
                builder.AppendLine($"The total number of cells is: {totalCells}");
                return builder.ToString();
            }

            for (int i = 0; i < n; i++)
            {
                var strA = string.Join(", ", a[i]);
                var strB = string.Join(", ", b[i]);
                builder.AppendLine("[" + strA + ", " + strB + "]");
            }

            return builder.ToString();
        }
    }
}

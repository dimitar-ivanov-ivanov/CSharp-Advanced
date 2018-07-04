namespace BunkerBuster
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        public static void Execute()
        {
            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var n = int.Parse(args[0]);
            var m = int.Parse(args[1]);

            var matrix = new decimal[n, m];

            for (int i = 0; i < n; i++)
            {
                args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < args.Length; j++)
                {
                    matrix[i, j] = int.Parse(args[j]);
                }
            }

            args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            while (!string.Join(" ", args).Equals("cease fire!"))
            {
                var row = int.Parse(args[0]);
                var col = int.Parse(args[1]);
                var val = (int)args[2][0];
                var outerDamage = Math.Round((decimal)val / 2, MidpointRounding.AwayFromZero);

                if (InMatrix(row, col, n, m)) matrix[row, col] -= val;
                if (InMatrix(row, col - 1, n, m)) matrix[row, col - 1] -= outerDamage;
                if (InMatrix(row, col + 1, n, m)) matrix[row, col + 1] -= outerDamage;


                if (InMatrix(row - 1, col - 1, n, m)) matrix[row - 1, col - 1] -= outerDamage;
                if (InMatrix(row - 1, col + 1, n, m)) matrix[row - 1, col + 1] -= outerDamage;
                if (InMatrix(row - 1, col, n, m)) matrix[row - 1, col] -= outerDamage;

                if (InMatrix(row + 1, col - 1, n, m)) matrix[row + 1, col - 1] -= outerDamage;
                if (InMatrix(row + 1, col + 1, n, m)) matrix[row + 1, col + 1] -= outerDamage;
                if (InMatrix(row + 1, col, n, m)) matrix[row + 1, col] -= outerDamage;

                args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            var totalCells = n * m;
            var bombed = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] <= 0)
                    {
                        bombed++;
                    }
                }
            }

            var perc = (double)bombed / totalCells * 100;
            Console.WriteLine($"Destroyed bunkers: {bombed}");
            Console.WriteLine($"Damage done: {perc:F1} %");
        }

        private static bool InMatrix(int row, int col, int n, int m)
        {
            return row >= 0 && row < n && col >= 0 && col < m;
        }
    }
}

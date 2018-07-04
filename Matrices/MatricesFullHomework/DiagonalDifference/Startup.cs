using System;

namespace DiagonalDifference
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Execute());
        }

        private static int Execute()
        {
            var leftToRight = 0;
            var rightToLeft = 0;
            var n = int.Parse(Console.ReadLine());
            var matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = int.Parse(args[j]);
                }
            }

            for (int i = 0; i < n; i++)
            {
                leftToRight += matrix[i, i];
            }

            for (int i = 0, j = n - 1; i < n && j >= 0; i++, j--)
            {
                rightToLeft += matrix[i, j];
            }

            return Math.Abs(leftToRight - rightToLeft);
        }
    }
}

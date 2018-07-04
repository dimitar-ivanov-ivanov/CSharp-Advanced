namespace MaximumSum
{
    using System;
    using System.Text;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Execute());
        }

        private static string Execute()
        {
            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var n = int.Parse(args[0]);
            var m = int.Parse(args[1]);
            var matrix = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = int.Parse(args[j]);
                }
            }

            var maxSum = 0;
            var startRow = 0;
            var startCol = 0;

            for (int i = 0; i < n - 2; i++)
            {
                for (int j = 0; j < m - 2; j++)
                {
                    var sum = 0;
                    for (int k = i; k < i + 3 && k < n; k++)
                    {
                        for (int p = j; p < j + 3 && p < m; p++)
                        {
                            sum += matrix[k, p];
                        }
                    }

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        startRow = i;
                        startCol = j;
                    }
                }
            }

            var builder = new StringBuilder();
            builder.AppendLine($"Sum = {maxSum}");
            for (int i = startRow; i < startRow + 3; i++)
            {
                for (int j = startCol; j < startCol + 3; j++)
                {
                    builder.Append(matrix[i, j] + " ");
                }
                builder.AppendLine();
            }

            return builder.ToString();
        }
    }
}

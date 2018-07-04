namespace _2X2Submatrix
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
            var args = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            var n = int.Parse(args[0]);
            var m = int.Parse(args[1]);
            var sum = 0;
            var matrix = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                args = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = int.Parse(args[j]);
                    sum += matrix[i, j];
                }
            }

            var builder = new StringBuilder();
            var maxSum = 0;
            var startRow = 0;
            var startCol = 0;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < m - 1; j++)
                {
                    sum = 0;
                    for (int k = i; k < n && k < i + 2; k++)
                    {
                        for (int p = j; p < m && p < j + 2; p++)
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

            for (int i = startRow; i < startRow + 2; i++)
            {
                for (int j = startCol; j < startCol + 2; j++)
                {
                    builder.Append(matrix[i, j] + " ");
                }
                if (builder.Length != 0)
                {
                    builder = builder.Remove(builder.Length - 1, 1);
                }
                builder.AppendLine();
            }


            builder.AppendLine(maxSum + "");
            if (builder.Length != 0)
            {
                builder = builder.Remove(builder.Length - 1, 1);
            }

            return builder.ToString();
        }
    }
}

namespace PascalTriangle
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
            var n = int.Parse(Console.ReadLine());
            var matrix = new long[n][];
            var builder = new StringBuilder();

            matrix[0] = new long[] { 1 };
            builder.AppendLine(matrix[0][0] + " ");

            for (int i = 1; i < n; i++)
            {
                matrix[i] = new long[matrix[i - 1].Length + 1];
                matrix[i][0] = 1;
                matrix[i][matrix[i].Length - 1] = 1;
                builder.Append(matrix[i][0] + " ");

                for (int j = 1; j < matrix[i].Length - 1; j++)
                {
                    matrix[i][j] = matrix[i - 1][j - 1] + matrix[i - 1][j];
                    builder.Append(matrix[i][j] + " ");
                }

                builder.Append(matrix[i][matrix[i].Length - 1] + " ");
                builder.AppendLine();
            }

            return builder.ToString();
        }
    }
}

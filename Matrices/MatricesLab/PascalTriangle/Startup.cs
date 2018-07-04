namespace PascalTriangle
{
    using System;
    using System.Text;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            Console.WriteLine(Execute(n));
        }

        private static string Execute(long n)
        {
            var res = new StringBuilder("1\n");
            var matrix = new long[n][];
            matrix[0] = new long[] { 1 };

            for (long i = 1; i < n; i++)
            {
                matrix[i] = new long[matrix[i - 1].Length + 1];
                matrix[i][0] = matrix[i - 1][0];
                matrix[i][matrix[i].Length - 1] = 1;

                for (long j = 1; j < matrix[i].Length - 1; j++)
                {
                    matrix[i][j] = matrix[i - 1][j - 1] + matrix[i - 1][j];
                }
                res.AppendLine(string.Join(" ", matrix[i]));
            }

            return res.ToString();
        }
    }
}

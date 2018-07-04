namespace SumMatrix
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
            builder.AppendLine(n + "");
            builder.AppendLine(m + "");
            builder.AppendLine(sum + "");
            return builder.ToString();
        }
    }
}

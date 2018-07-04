namespace Crossfire
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Startup
    {
        static int n;
        static int m;

        public static void Main(string[] args)
        {
            Console.WriteLine(Execute());
        }

        private static string Execute()
        {
            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            n = int.Parse(args[0]);
            m = int.Parse(args[1]);
            var matrix = new List<int>[n];

            for (int i = 0, sum = 1; i < n; i++)
            {
                matrix[i] = new List<int>(m);
                for (int j = 0; j < m; j++, sum++)
                {
                    matrix[i].Add(sum);
                }
            }

            args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            while (!string.Join(" ", args).Equals("Nuke it from orbit"))
            {
                var row = int.Parse(args[0]);
                var col = int.Parse(args[1]);
                var radius = int.Parse(args[2]);
                FireAtMatrix(matrix, row, col, radius);
                args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            return Print(matrix);
        }

        private static string Print(List<int>[] matrix)
        {
            var builder = new StringBuilder();

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Count; j++)
                {
                    if (matrix[i][j] != -1)
                    {
                        builder.Append(matrix[i][j] + " ");
                    }
                }

                builder.AppendLine();
            }

            return builder.ToString();
        }

        private static void FireAtMatrix(List<int>[] matrix, int row, int col, int radius)
        {
            var startRow = row - radius < 0 ? 0 : row - radius;
            var startCol = col - radius < 0 ? 0 : col - radius;
            var endRow = row + radius >= n ? n - 1 : row + radius;
            var endCol = col + radius >= m ? m - 1 : col + radius;

            for (int i = startRow; i <= endRow; i++)
            {
                if (matrix[i].Count > col)
                {
                    matrix[i][col] = -1;
                }
            }

            for (int j = startCol; j <= endCol; j++)
            {
                if (matrix[row].Count > j)
                {
                    matrix[row][j] = -1;
                }
                else
                {
                    break;
                }
            }

            for (int i = startRow; i <= endRow; i++)
            {
                matrix[i].RemoveAll(x => x == -1);
            }
        }
    }
}

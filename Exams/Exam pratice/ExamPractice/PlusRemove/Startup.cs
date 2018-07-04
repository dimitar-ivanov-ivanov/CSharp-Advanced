namespace PlusRemove
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var m = 0;
            var list = new List<string>();
            var line = Console.ReadLine();

            while (line != "END")
            {
                list.Add(line);
                m = Math.Max(line.Length, m);
                line = Console.ReadLine();
            }

            var n = list.Count;
            var matrix = new char[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (j < list[i].Length)
                    {
                        matrix[i, j] = list[i][j];
                    }
                }
            }

            var visited = new bool[n, m];
            for (int i = 1; i < n - 1; i++)
            {
                for (int j = 1; j < m - 1; j++)
                {
                    if (CreatesPlusShape(i, j, matrix))
                    {
                        VisitAllCells(i, j, visited);
                    }
                }
            }

            var builder = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (!visited[i, j])
                    {
                        builder.Append(matrix[i, j]);
                    }
                }

                builder.AppendLine();
            }

            Console.WriteLine(builder.ToString());
        }

        private static bool CreatesPlusShape(int i, int j, char[,] matrix)
        {
            var lower =
                matrix[i - 1, j].ToString().ToLower()[0] == matrix[i, j] &&
                matrix[i, j + 1].ToString().ToLower()[0] == matrix[i, j] &&
                matrix[i, j - 1].ToString().ToLower()[0] == matrix[i, j] &&
                matrix[i + 1, j].ToString().ToLower()[0] == matrix[i, j];

            var upper =
            matrix[i - 1, j].ToString().ToUpper()[0] == matrix[i, j] &&
            matrix[i, j + 1].ToString().ToUpper()[0] == matrix[i, j] &&
            matrix[i, j - 1].ToString().ToUpper()[0] == matrix[i, j] &&
            matrix[i + 1, j].ToString().ToUpper()[0] == matrix[i, j];

            return lower ? lower : upper;
        }

        private static void VisitAllCells(int i, int j, bool[,] visited)
        {
            visited[i - 1, j] = true;
            visited[i, j + 1] = true;
            visited[i, j - 1] = true;
            visited[i + 1, j] = true;
            visited[i, j] = true;
        }
    }
}

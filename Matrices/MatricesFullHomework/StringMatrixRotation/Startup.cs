namespace StringMatrixRotation
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Execute());
        }

        private static string Execute()
        {
            var args = Console.ReadLine()
                .Split(new[] { ' ', ')', '(' }, StringSplitOptions.RemoveEmptyEntries);
            var angle = int.Parse(args[1]);
            var matrix = ReadMatrix();

            if (angle == 0)
            {
                return Print(matrix);
            }

            angle /= 90;
            angle %= 4;
            for (int i = 0; i < angle; i++)
            {
                matrix = Rotate(matrix);
            }

            return Print(matrix);
        }

        private static char[,] Rotate(char[,] matrix)
        {
            var n = matrix.GetLength(1);
            var m = matrix.GetLength(0);
            var newMatrix = new char[n, m];

            for (int j = 0; j < m; j++)
            {
                var row = matrix.GetLength(0) - 1 - j;
                for (int i = 0; i < n; i++)
                {
                    var col = i;
                    newMatrix[i, j] = matrix[row, col];
                }
            }

            return newMatrix;
        }

        private static string Print(char[,] matrix)
        {
            var builder = new StringBuilder();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    builder.Append(matrix[i, j].ToString());
                }
                builder.AppendLine();
            }
            return builder.ToString();
        }

        private static char[,] ReadMatrix()
        {
            var line = Console.ReadLine();
            var maxCol = 0;
            var list = new List<string>();

            while (line != "END")
            {
                list.Add(line);
                if (line.Length > maxCol)
                {
                    maxCol = line.Length;
                }
                line = Console.ReadLine();
            }

            var matrix = new char[list.Count, maxCol];

            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < maxCol; j++)
                {
                    if (j >= list[i].Length)
                    {
                        matrix[i, j] = ' ';
                    }
                    else
                    {
                        matrix[i, j] = list[i][j];
                    }
                }
            }

            return matrix;
        }
    }
}

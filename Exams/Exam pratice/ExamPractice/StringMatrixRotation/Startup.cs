namespace StringMatrixRotation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var args = Console.ReadLine().Split(new[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            var angle = int.Parse(args[1]);
            var matrix = new List<List<char>>();
            var line = Console.ReadLine();
            var maxCol = 0;

            while (line != "END")
            {
                matrix.Add(line.ToCharArray().ToList());
                maxCol = Math.Max(maxCol, line.Length);
                line = Console.ReadLine();
            }

            for (int i = 0; i < matrix.Count; i++)
            {
                if (matrix[i].Count < maxCol)
                {
                    for (int j = matrix[i].Count; j < maxCol; j++)
                    {
                        matrix[i].Add(' ');
                    }
                }
            }

            angle %= 360;
            if (angle == 90)
            {
                matrix = Rotate90(matrix);
            }
            else if (angle == 180)
            {
                matrix = Rotate180(matrix);
            }
            else if (angle == 270)
            {
                matrix = Rotate270(matrix);
            }

            Console.WriteLine(Print(matrix));
        }

        private static string Print(List<List<char>> matrix)
        {
            var builder = new StringBuilder();
            for (int i = 0; i < matrix.Count; i++)
            {
                for (int j = 0; j < matrix[i].Count; j++)
                {
                    builder.Append(matrix[i][j]);
                }
                builder.AppendLine();
            }

            return builder.ToString();
        }

        private static List<List<char>> Rotate90(List<List<char>> matrix)
        {
            var newMatrix = new List<List<char>>();

            for (int j = 0; j < matrix[0].Count; j++)
            {
                newMatrix.Add(new List<char>());
                for (int i = matrix.Count - 1; i >= 0; i--)
                {
                    newMatrix[j].Add(matrix[i][j]);
                }
            }

            return newMatrix;
        }

        private static List<List<char>> Rotate180(List<List<char>> matrix)
        {
            var newMatrix = new List<List<char>>();

            for (int i = matrix.Count - 1; i >= 0; i--)
            {
                newMatrix.Add(new List<char>());
                for (int j = matrix[i].Count - 1; j >= 0; j--)
                {
                    newMatrix[newMatrix.Count - 1].Add(matrix[i][j]);
                }
            }

            return newMatrix;
        }

        private static List<List<char>> Rotate270(List<List<char>> matrix)
        {
            var newMatrix = new List<List<char>>();

            for (int j = matrix[0].Count - 1; j >= 0; j--)
            {
                newMatrix.Add(new List<char>());
                for (int i = 0; i < matrix.Count; i++)
                {
                    newMatrix[newMatrix.Count - 1].Add(matrix[i][j]);
                }
            }

            return newMatrix;
        }
    }
}
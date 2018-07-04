namespace Sneaking
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
            var n = int.Parse(Console.ReadLine());
            var matrix = new List<char[]>();
            var playerRow = 0;
            var playerCol = 0;

            for (int i = 0; i < n; i++)
            {
                matrix.Add(Console.ReadLine().ToCharArray());
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'S')
                    {
                        playerRow = i;
                        playerCol = j;
                    }
                }
            }

            var directions = Console.ReadLine();

            for (int i = 0; i < directions.Length; i++)
            {
                matrix[playerRow][playerCol] = '.';
                MoveEnemies(matrix);

                if (matrix[playerRow][playerCol] == 'd' ||
                   matrix[playerRow][playerCol] == 'b')
                {
                    matrix[playerRow][playerCol] = 'S';
                }

                for (int j = 0; j < matrix[playerRow].Length; j++)
                {
                    if (matrix[playerRow][j] == 'N')
                    {
                        matrix[playerRow][j] = 'X';
                        matrix[playerRow][playerCol] = 'S';
                        PrintMatrix(matrix, "Nikoladze killed!");
                        return;
                    }
                }

                for (int j = 0; j < playerCol; j++)
                {
                    if (matrix[playerRow][j] == 'b')
                    {
                        matrix[playerRow][playerCol] = 'X';
                        PrintMatrix(matrix, $"Sam died at {playerRow}, {playerCol}");
                        return;
                    }
                }

                for (int j = playerCol + 1; j < matrix[playerRow].Length; j++)
                {
                    if (matrix[playerRow][j] == 'd')
                    {
                        matrix[playerRow][playerCol] = 'X';
                        PrintMatrix(matrix, $"Sam died at {playerRow}, {playerCol}");
                        return;
                    }
                }

                switch (directions[i])
                {
                    case 'U':
                        playerRow--;
                        break;
                    case 'D':
                        playerRow++;
                        break;
                    case 'L':
                        playerCol--;
                        break;
                    case 'R':
                        playerCol++;
                        break;
                    case 'W':
                        break;
                    default:
                        break;
                }

                matrix[playerRow][playerCol] = 'S';

                for (int j = 0; j < matrix[playerRow].Length; j++)
                {
                    if (matrix[playerRow][j] == 'N')
                    {
                        matrix[playerRow][j] = 'X';
                        matrix[playerRow][playerCol] = 'S';
                        PrintMatrix(matrix, "Nikoladze killed!");
                        return;
                    }
                }
            }
        }

        private static void PrintMatrix(List<char[]> matrix, string message)
        {
            var builder = new StringBuilder();
            builder.AppendLine(message);

            for (int i = 0; i < matrix.Count; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    builder.Append(matrix[i][j]);
                }
                builder.AppendLine();
            }
            Console.WriteLine(builder);
        }

        private static void MoveEnemies(List<char[]> matrix)
        {
            for (int i = 0; i < matrix.Count; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'd')
                    {
                        if (j == 0)
                        {
                            matrix[i][j] = 'b';
                        }
                        else
                        {
                            matrix[i][j - 1] = 'd';
                            matrix[i][j] = '.';
                        }

                        break;
                    }
                    else if (matrix[i][j] == 'b')
                    {
                        if (j == matrix[i].Length - 1)
                        {
                            matrix[i][j] = 'd';
                        }
                        else
                        {
                            matrix[i][j + 1] = 'b';
                            matrix[i][j] = '.';
                        }

                        break;
                    }
                }
            }
        }
    }
}
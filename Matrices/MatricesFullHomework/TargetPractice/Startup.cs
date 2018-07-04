namespace TargetPractice
{
    using System;
    using System.Text;

    public class Startup
    {
        const char destroyedElement = ' ';

        public static void Main(string[] args)
        {
            Console.WriteLine(Execute());
        }

        private static string Print(char[][] matrix)
        {
            var builder = new StringBuilder();
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    builder.Append(matrix[i][j]);
                }
                builder.AppendLine();
            }
            return builder.ToString();
        }

        private static string Execute()
        {
            var matrix = ReadMatrix();
            DestroyMatrix(matrix);
            CollapseMatrix(matrix);
            return Print(matrix);
        }

        private static void CollapseMatrix(char[][] matrix)
        {
            for (int i = matrix.Length - 2; i >= 0; i--)
            {
                for (int j = matrix[0].Length - 1; j >= 0; j--)
                {
                    if (matrix[i][j] != destroyedElement &&
                        matrix[i + 1][j] == destroyedElement)
                    {
                        for (int k = i + 1; k < matrix.Length; k++)
                        {
                            if (matrix[k][j] != destroyedElement)
                            {
                                matrix[k - 1][j] = matrix[i][j];
                                matrix[i][j] = destroyedElement;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private static void DestroyMatrix(char[][] matrix)
        {
            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var impactRow = int.Parse(args[0]);
            var impactCol = int.Parse(args[1]);
            var radius = int.Parse(args[2]);

            for (int i = impactRow - radius; i <= impactRow + radius; i++)
            {
                for (int j = impactCol - radius; j <= impactCol + radius; j++)
                {
                    if (i >= 0 && j >= 0 && i < matrix.Length && j < matrix[0].Length &&
                        isWithinShootingRange(matrix, impactRow, impactCol, radius, i, j))
                    {
                        matrix[i][j] = destroyedElement;
                    }
                }
            }
        }

        private static char[][] ReadMatrix()
        {
            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var n = int.Parse(args[0]);
            var m = int.Parse(args[1]);
            var matrix = new char[n][];
            var word = Console.ReadLine();
            var diff = 1;

            for (int i = n - 1, index = 0; i >= 0; i--)
            {
                matrix[i] = new char[m];
                var start = 0;
                if (diff == 1)
                {
                    start = m - 1;
                }
                else
                {
                    start = 0;
                }

                for (int j = start; j >= 0 && j < m; j -= diff, index++)
                {
                    if (index == word.Length)
                    {
                        index = 0;
                    }
                    matrix[i][j] = word[index];
                }

                diff = -diff;
            }

            return matrix;
        }

        private static bool isWithinShootingRange(char[][] matrix, int impactRow, int impactCol, int radius, int row, int col)
        {
            var distance = Math.Sqrt(Math.Pow(impactRow - row, 2) + Math.Pow(impactCol - col, 2));
            return distance <= radius;
        }
    }
}

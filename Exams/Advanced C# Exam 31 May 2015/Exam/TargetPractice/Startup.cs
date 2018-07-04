namespace TargetPractice
{
    using System;
    using System.Text;

    public class Startup
    {
        private const char destroyedElement = ' ';

        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var n = int.Parse(args[0]);
            var m = int.Parse(args[1]);
            var matrix = new char[n, m];
            FillMatrix(n, m, matrix);
            ShootMatrix(n, m, matrix);
            CollapseMatri(n, m, matrix);
            Print(n, m, matrix);
        }

        private static void Print(int n, int m, char[,] matrix)
        {
            var builder = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    builder.Append(matrix[i, j]);
                }
                builder.AppendLine();
            }

            Console.Write(builder);
        }

        private static void CollapseMatri(int n, int m, char[,] matrix)
        {
            for (int i = n - 2; i >= 0; i--)
            {
                for (int j = m - 1; j >= 0; j--)
                {
                    if (matrix[i + 1, j] == destroyedElement)
                    {
                        for (int k = i + 1; k < n; k++)
                        {
                            if (matrix[k, j] == destroyedElement)
                            {
                                var temp = matrix[k, j];
                                matrix[k, j] = matrix[k - 1, j];
                                matrix[k - 1, j] = temp;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        private static void FillMatrix(int n, int m, char[,] matrix)
        {
            var line = Console.ReadLine();
            var index = 0;
            var colVal = -1;
            var startCol = m - 1;

            for (int i = n - 1; i >= 0; i--)
            {
                for (int j = startCol; j < m && j >= 0;
                    j += colVal, index = (index + 1) % line.Length)
                {
                    matrix[i, j] = line[index];
                }

                colVal = -colVal;
                if (startCol == m - 1)
                {
                    startCol = 0;
                }
                else
                {
                    startCol = m - 1;
                }
            }
        }

        private static void ShootMatrix(int n, int m, char[,] matrix)
        {
            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var impactRow = int.Parse(args[0]);
            var impactCol = int.Parse(args[1]);
            var radius = int.Parse(args[2]);

            for (int i = impactRow - radius; i <= impactRow + radius && i < n; i++)
            {
                for (int j = impactCol - radius; j <= impactCol + radius; j++)
                {
                    if (!WithinMatrix(i, j, n, m)) { continue; }

                    if (IsWithinShootingRange(matrix, impactRow, impactCol, radius, i, j))
                    {
                        matrix[i, j] = destroyedElement;
                    }
                }
            }
        }

        private static bool IsWithinShootingRange(char[,] matrix, int impactRow, int impactCol, int radius, int i, int j)
        {
            var distance = Math.Sqrt(Math.Pow(impactRow - i, 2) +
                Math.Pow(impactCol - j, 2));

            return distance <= radius;
        }

        private static bool WithinMatrix(int i, int j, int n, int m)
        {
            return i >= 0 && i < n && j >= 0 && j < m;
        }
    }
}
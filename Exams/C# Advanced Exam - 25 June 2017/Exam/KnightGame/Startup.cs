namespace KnightGame
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Execute());
        }

        private static string Execute()
        {
            var matrix = ReadMatrix();
            var mostDangerousRow = 0;
            var mostDangerousCol = 0;
            var mostKnightsHit = 0;
            var count = 0;

            while (true)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        var knightsHit = 0;
                        if (matrix[i, j] != 'K')
                        {
                            continue;
                        }

                        if (InMatrix(i - 2, j - 1, matrix.GetLength(0)) && matrix[i - 2, j - 1] == 'K')
                        {
                            knightsHit++;
                        }
                        if (InMatrix(i - 2, j + 1, matrix.GetLength(0)) && matrix[i - 2, j + 1] == 'K')
                        {
                            knightsHit++;
                        }
                        if (InMatrix(i - 1, j - 2, matrix.GetLength(0)) && matrix[i - 1, j - 2] == 'K')
                        {
                            knightsHit++;
                        }
                        if (InMatrix(i - 1, j + 2, matrix.GetLength(0)) && matrix[i - 1, j + 2] == 'K')
                        {
                            knightsHit++;
                        }

                        if (InMatrix(i + 2, j - 1, matrix.GetLength(0)) && matrix[i + 2, j - 1] == 'K')
                        {
                            knightsHit++;
                        }
                        if (InMatrix(i + 2, j + 1, matrix.GetLength(0)) && matrix[i + 2, j + 1] == 'K')
                        {
                            knightsHit++;
                        }
                        if (InMatrix(i + 1, j - 2, matrix.GetLength(0)) && matrix[i + 1, j - 2] == 'K')
                        {
                            knightsHit++;
                        }
                        if (InMatrix(i + 1, j + 2, matrix.GetLength(0)) && matrix[i + 1, j + 2] == 'K')
                        {
                            knightsHit++;
                        }

                        if (mostKnightsHit < knightsHit)
                        {
                            mostKnightsHit = knightsHit;
                            mostDangerousCol = j;
                            mostDangerousRow = i;
                        }
                    }
                }
                if (mostKnightsHit == 0)
                {
                    return count.ToString();
                }
                else
                {
                    mostKnightsHit = 0;
                    matrix[mostDangerousRow, mostDangerousCol] = '0';
                    count++;
                }
            }
        }

        private static bool InMatrix(int row, int col, int n)
        {
            return row >= 0 && row < n && col >= 0 && col < n;
        }

        private static char[,] ReadMatrix()
        {
            var n = int.Parse(Console.ReadLine());
            var matrix = new char[n, n];

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = line[j];
                }
            }

            return matrix;
        }
    }
}
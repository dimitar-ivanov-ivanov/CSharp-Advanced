namespace MatrixShuffle
{
    using System;
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
            var n = int.Parse(Console.ReadLine());
            var line = Console.ReadLine();
            var matrix = new char[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = default(char);
                }
            }

            FillMatrix(matrix, n, n, 0, 0, line, 0);
            var whites = GetColor(matrix, n, 0);
            var blacks = GetColor(matrix, n, 1);

            var res = (whites + blacks).ToLower();
            var reverse = new string(res.Reverse().ToArray());


            res = res.Replace(default(Char), ' ').Replace(" ", "").Replace(".", "").Replace(",", "");
            reverse = reverse.Replace(default(char), ' ').Replace(" ", "").Replace(".", "").Replace(",", "");

            if (res == reverse)
            {
                Console.WriteLine($"<div style='background-color:#4FE000'>{whites + blacks}</div>");
            }
            else
            {
                Console.WriteLine($"<div style='background-color:#E0000F'>{whites + blacks}</div>");
            }

        }

        private static string GetColor(char[,] matrix, int n, int remainder)
        {
            var builder = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j % 2 == remainder)
                    {
                        builder.Append(matrix[i, j]);
                    }
                }

                remainder = remainder == 0 ? 1 : 0;
            }

            return builder.ToString();
        }

        private static void FillMatrix(char[,] matrix, int n, int m, int row, int col, string sentence, int count)
        {
            if (count == sentence.Length)
            {
                return;
            }

            matrix[row, col] = sentence[count];

            if (col < m - 1 && row < n - 1 &&
                matrix[row, col + 1] == default(char) && matrix[row + 1, col] == default(char))
            {
                FillMatrix(matrix, n, m, row, col + 1, sentence, count + 1);
            }
            else if (col > 0 && row < n - 1 &&
                matrix[row, col - 1] == default(char) && matrix[row + 1, col] == default(char))
            {
                FillMatrix(matrix, n, m, row + 1, col, sentence, count + 1);
            }
            else if (row > 0 && col > 0 &&
                     matrix[row - 1, col] == default(char) && matrix[row, col - 1] == default(char))
            {
                FillMatrix(matrix, n, m, row, col - 1, sentence, count + 1);
            }
            else if (row > 0 && col < m - 1 &&
                    matrix[row - 1, col] == default(char) && matrix[row, col + 1] == default(char))
            {
                FillMatrix(matrix, n, m, row - 1, col, sentence, count + 1);
            }
            else if (row < n - 1 && matrix[row + 1, col] == default(char))
            {
                FillMatrix(matrix, n, m, row + 1, col, sentence, count + 1);
            }
            else if (col > 0 && matrix[row, col - 1] == default(char))
            {
                FillMatrix(matrix, n, m, row, col - 1, sentence, count + 1);
            }
            else if (row > 0 && matrix[row - 1, col] == default(char))
            {
                FillMatrix(matrix, n, m, row - 1, col, sentence, count + 1);
            }
            else if (col < m - 1 && matrix[row, col + 1] == default(char))
            {
                FillMatrix(matrix, n, m, row, col + 1, sentence, count + 1);
            }
        }
    }
}
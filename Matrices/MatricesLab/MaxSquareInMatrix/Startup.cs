namespace MaxSquareInMatrix
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
            var res = new StringBuilder();
            var args = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            var n = int.Parse(args[0]);
            var m = int.Parse(args[1]);
            var matrix = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                args = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = int.Parse(args[j]);
                }
            }

            var maxSquare = int.MinValue;
            var startRow = 0;
            var startCol = 0;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < m - 1; j++)
                {
                    var currentSquare = 0;
                    for (int k = i; k < i + 2 && k < n; k++)
                    {
                        for (int p = j; p < j + 2 && p < m; p++)
                        {
                            currentSquare += matrix[k, p];
                        }
                    }

                    if (currentSquare > maxSquare)
                    {
                        maxSquare = currentSquare;
                        startRow = i;
                        startCol = j;
                    }
                }
            }

            for (int i = startRow; i < startRow + 2; i++)
            {
                res.AppendLine(matrix[i, startCol].ToString() + " "
                    + matrix[i, startCol + 1]);
            }

            res.AppendLine(maxSquare.ToString());

            return res.ToString();
        }
    }
}

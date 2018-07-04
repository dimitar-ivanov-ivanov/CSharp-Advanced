namespace _2X2SquareInMatrix
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Execute());
        }

        private static int Execute()
        {
            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var n = int.Parse(args[0]);
            var m = int.Parse(args[1]);
            var matrix = new char[n, m];

            for (int i = 0; i < n; i++)
            {
                args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = args[j][0];
                }
            }

            var res = 0;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < m - 1; j++)
                {
                    var first = matrix[i, j];
                    var isEqualSquare = true;

                    for (int k = i; k < i + 2 && k < n; k++)
                    {
                        for (int p = j; p < j + 2 && p < m; p++)
                        {
                            if (matrix[k, p] != matrix[i, j])
                            {
                                isEqualSquare = false;
                                break;
                            }
                        }
                        if (!isEqualSquare) break;

                    }

                    if (isEqualSquare) res++;
                }
            }

            return res;
        }
    }
}
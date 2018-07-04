namespace JediGalaxy
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            while (!string.Join(" ", args).Equals("Let the Force be with you"))
            {
                var n = int.Parse(args[0]);
                var m = int.Parse(args[1]);

                args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var startRow = int.Parse(args[0]);
                var startCol = int.Parse(args[1]);

                args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var badRow = int.Parse(args[0]);
                var badCol = int.Parse(args[1]);

                var matrix = new int[n, m];
                for (int i = 0, sum = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++, sum++)
                    {
                        matrix[i, j] = sum;
                    }
                }

                while (badRow >= 0 && badCol >= 0)
                {
                    badRow--;
                    badCol--;
                    if (InMatrix(n, m, badRow, badCol))
                    {
                        matrix[badRow, badCol] = 0;
                    }
                }

                long res = 0;
                while (startRow >= 0 && startCol < m)
                {
                    startRow--;
                    startCol++;
                    if (InMatrix(n, m, startRow, startCol))
                    {
                        res += matrix[startRow, startCol];
                    }
                }

                Console.WriteLine(res);
                args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }
        }

        private static bool InMatrix(int n, int m, long startRow, long startCol)
        {
            return startRow >= 0 && startRow < n && startCol >= 0 && startCol < m;
        }
    }
}

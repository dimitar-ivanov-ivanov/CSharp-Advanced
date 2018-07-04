namespace RadioactiveMutantVampireBunnies
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Startup
    {
        static int n;
        static int m;
        static int playerRow;
        static int playerCol;
        static char[,] matrix;
        static bool[,] bunnies;

        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            Initialize();
            MovePlayer();

        }

        private static void MovePlayer()
        {
            var directions = Console.ReadLine();
            for (int i = 0; i < directions.Length; i++)
            {
                matrix[playerRow, playerCol] = '.';
                Mark();

                switch (directions[i])
                {
                    case 'U':
                        if (playerRow == 0)
                        {
                            Print("won");
                            return;
                        }
                        playerRow--;
                        break;
                    case 'L':
                        if (playerCol == 0)
                        {
                            Print("won");
                            return;
                        }
                        playerCol--;
                        break;
                    case 'D':
                        if (playerRow == n - 1)
                        {
                            Print("won");
                            return;
                        }
                        playerRow++;
                        break;
                    case 'R':
                        if (playerCol == m - 1)
                        {
                            Print("won");
                            return;
                        }
                        playerCol++;
                        break;
                    default:
                        break;
                }

                if (matrix[playerRow, playerCol] == 'B')
                {
                    Print("dead");
                    return;
                }
                else
                {
                    matrix[playerRow, playerCol] = 'P';
                }
            }
        }

        private static void Mark()
        {
            var newBunnies = new List<KeyValuePair<int, int>>();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (bunnies[i, j])
                    {
                        bunnies[i, j] = false;
                        newBunnies.Add(new KeyValuePair<int, int>(i - 1, j));
                        newBunnies.Add(new KeyValuePair<int, int>(i, j - 1));
                        newBunnies.Add(new KeyValuePair<int, int>(i, j + 1));
                        newBunnies.Add(new KeyValuePair<int, int>(i + 1, j));
                    }
                }
            }

            foreach (var newBunny in newBunnies)
            {
                var row = newBunny.Key;
                var col = newBunny.Value;
                if (row >= 0 && row < n && col >= 0 && col < m)
                {
                    bunnies[row, col] = true;
                    matrix[row, col] = 'B';
                }
            }
        }

        private static void Print(string message)
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
            builder.AppendLine($"{message}: {playerRow} {playerCol}");
            Console.WriteLine(builder);
        }

        private static void Initialize()
        {
            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            n = int.Parse(args[0]);
            m = int.Parse(args[1]);

            matrix = new char[n, m];
            bunnies = new bool[n, m];

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = line[j];
                    bunnies[i, j] = matrix[i, j] == 'B';
                    if (matrix[i, j] == 'P')
                    {
                        playerRow = i;
                        playerCol = j;
                    }
                }
            }
        }
    }
}
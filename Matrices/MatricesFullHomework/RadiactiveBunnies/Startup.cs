namespace RadiactiveBunnies
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Execute());
        }

        private static string Execute()
        {
            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var n = int.Parse(args[0]);
            var m = int.Parse(args[1]);
            var matrix = new char[n][];
            var bunnies = new bool[n][];
            var playerRow = 0;
            var playerCol = 0;
            var playerStatus = "";

            for (int i = 0; i < n; i++)
            {
                matrix[i] = new char[m];
                bunnies[i] = new bool[m];
                var line = Console.ReadLine();

                for (int j = 0; j < m; j++)
                {
                    matrix[i][j] = line[j];
                    bunnies[i][j] = matrix[i][j] == 'B';
                    if (matrix[i][j] == 'P')
                    {
                        playerRow = i;
                        playerCol = j;
                    }
                }
            }

            var directions = Console.ReadLine();
            var index = 0;

            while (playerRow >= 0 && playerRow < n &&
                   playerCol >= 0 && playerCol < m)
            {
                MoveBunnies(matrix, bunnies);
                var escaped = false;

                if (!bunnies[playerRow][playerCol])
                {
                    matrix[playerRow][playerCol] = '.';
                }

                switch (directions[index])
                {
                    case 'U':
                        playerRow--;
                        if (playerRow < 0)
                        {
                            playerRow++;
                            playerStatus = "won";
                            escaped = true;
                        }
                        break;
                    case 'L':
                        playerCol--;
                        if (playerCol < 0)
                        {
                            playerCol++;
                            escaped = true;
                        }
                        break;
                    case 'R':
                        playerCol++;
                        if (playerCol == m)
                        {
                            playerCol--;
                            escaped = true;
                        }
                        break;
                    case 'D':
                        playerRow++;
                        if (playerRow == n)
                        {
                            playerRow--;
                            escaped = true;
                        }
                        break;
                    default:
                        break;
                }

                if (escaped)
                {
                    playerStatus = "won";
                    break;
                }

                if (bunnies[playerRow][playerCol])
                {
                    playerStatus = "dead";
                    break;
                }

                matrix[playerRow][playerCol] = 'P';
                index++;
            }

            return Print(matrix, playerStatus, playerRow, playerCol);
        }

        private static string Print(char[][] matrix, string playerStatus, int playerRow, int playerCol)
        {
            var builder = new StringBuilder();
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    builder.Append(matrix[i][j]);
                }
                builder.AppendLine();
            }

            builder.AppendLine($"{playerStatus}: {playerRow} {playerCol}");
            return builder.ToString();
        }

        private static void MoveBunnies(char[][] matrix, bool[][] bunnies)
        {
            var newBunnies = new List<KeyValuePair<int, int>>();

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    if (bunnies[i][j])
                    {
                        if (i - 1 >= 0) newBunnies.Add(new KeyValuePair<int, int>(i - 1, j));
                        if (j - 1 >= 0) newBunnies.Add(new KeyValuePair<int, int>(i, j - 1));
                        if (i + 1 < matrix.Length) newBunnies.Add(new KeyValuePair<int, int>(i + 1, j));
                        if (j + 1 < matrix[i].Length) newBunnies.Add(new KeyValuePair<int, int>(i, j + 1));
                    }
                }
            }

            for (int i = 0; i < newBunnies.Count; i++)
            {
                var key = newBunnies[i].Key;
                var val = newBunnies[i].Value;
                matrix[key][val] = 'B';
                bunnies[key][val] = true;
            }
        }
    }
}
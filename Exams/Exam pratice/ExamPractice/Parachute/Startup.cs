namespace Parachute
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var list = new List<string>();
            var m = 0;
            var line = Console.ReadLine();

            while (line != "END")
            {
                list.Add(line);
                m = Math.Max(m, line.Length);
                line = Console.ReadLine();
            }

            var n = list.Count;
            var matrix = new char[n, m];
            var playerRow = 0;
            var playerCol = 0;


            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = list[i][j];
                    if (matrix[i, j] == 'o')
                    {
                        playerRow = i;
                        playerCol = j;
                    }
                }
            }

            while (playerRow < n)
            {
                playerRow++;
                var goLeft = 0;
                var goRight = 0;
                GetMovement(matrix, playerRow, ref goLeft, ref goRight);

                if (goLeft > goRight)
                {
                    playerCol -= (goLeft - goRight);
                }
                else if (goLeft < goRight)
                {
                    playerCol += (goRight - goLeft);
                }

                switch (matrix[playerRow, playerCol])
                {
                    case '_':
                        Console.WriteLine("Landed on the ground like a boss!");
                        Console.WriteLine(playerRow + " " + playerCol);
                        return;
                    case '~':
                        Console.WriteLine("Drowned in the water like a cat!");
                        Console.WriteLine(playerRow + " " + playerCol);
                        return;
                    case '/':
                    case '\\':
                    case '|':
                        Console.WriteLine("Got smacked on the rock like a dog!");
                        Console.WriteLine(playerRow + " " + playerCol);
                        return;
                    default:
                        break;
                }
            }
        }

        private static void GetMovement(char[,] matrix, int playerRow, ref int goLeft, ref int goRight)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[playerRow, j] == '<') goLeft++;
                if (matrix[playerRow, j] == '>') goRight++;
            }
        }
    }
}

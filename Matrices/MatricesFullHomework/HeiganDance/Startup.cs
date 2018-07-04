namespace HeiganDance
{
    using System;
    using System.Globalization;
    using System.Text;
    using System.Threading;

    public class Startup
    {
        static int n = 15;
        static int plague = 3500;
        static bool plagueIsActive;
        static int eruption = 6000;
        static int playerRow = n / 2;
        static int playerCol = n / 2;
        static double heiganHealth = 3000000;
        static int playerHealth = 18500;

        public static void Main(string[] args)
        {
            Console.WriteLine(Execute());
        }

        private static string Execute()
        {
            var builder = new StringBuilder();
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var playerDamage = double.Parse(Console.ReadLine());

            while (true)
            {
                var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var spell = args[0];
                var row = int.Parse(args[1]);
                var col = int.Parse(args[2]);
                heiganHealth -= playerDamage;

                var startRow = row - 1 < 0 ? 0 : row - 1;
                var startCol = col - 1 < 0 ? 0 : col - 1;
                var endRow = row + 1 == n ? n - 1 : row + 1;
                var endCol = col + 1 == n ? n - 1 : col + 1;

                if (plagueIsActive)
                {
                    plagueIsActive = false;
                    playerHealth -= plague;
                }

                if (heiganHealth <= 0 && playerHealth <= 0)
                {
                    builder.AppendLine("Heigan: Defeated!");
                    builder.AppendLine("Player: Killed by Plague Cloud");
                    builder.AppendLine($"Final position: {playerRow}, {playerCol}");
                    break;
                }
                else if (heiganHealth <= 0)
                {
                    builder.AppendLine("Heigan: Defeated!");
                    builder.AppendLine($"Player: {playerHealth}");
                    builder.AppendLine($"Final position: {playerRow}, {playerCol}");
                    break;
                }
                else if (playerHealth <= 0)
                {
                    builder.AppendLine($"Heigan: {heiganHealth:f2}");
                    builder.AppendLine("Player: Killed by Plague Cloud");
                    builder.AppendLine($"Final position: {playerRow}, {playerCol}");
                    break;
                }

                TryToEscape(startRow, endRow, startCol, endCol);
                if (isWithinMatrix(startRow, endRow, startCol, endCol))
                {
                    if (spell == "Eruption")
                    {
                        playerHealth -= eruption;
                    }
                    else
                    {
                        playerHealth -= plague;
                        plagueIsActive = true;
                        spell = "Plague Cloud";
                    }
                };

                if (playerHealth <= 0)
                {
                    builder.AppendLine($"Heigan: {heiganHealth:f2}");
                    builder.AppendLine($"Player: Killed by {spell}");
                    builder.AppendLine($"Final position: {playerRow}, {playerCol}");
                    break;
                }
            }

            return builder.ToString();
        }

        private static void TryToEscape(int startRow, int endRow, int startCol, int endCol)
        {
            if (isWithinMatrix(startRow, endRow, startCol, endCol))
            {
                //go up
                playerRow--;
                if (isWithinMatrix(startRow, endRow, startCol, endCol)) playerRow++;
                else return;

                //go right
                playerCol++;
                if (isWithinMatrix(startRow, endRow, startCol, endCol)) playerCol--;
                else return;

                //go down
                playerRow++;
                if (isWithinMatrix(startRow, endRow, startCol, endCol)) playerRow--;
                else return;

                //go left 
                playerCol--;
                if (isWithinMatrix(startRow, endRow, startCol, endCol)) playerCol++;
                else return;
            }
        }

        private static bool isWithinMatrix(int startRow, int endRow, int startCol, int endCol)
        {
            return playerRow >= startRow && playerRow <= endRow &&
                   playerCol >= startCol && playerCol <= endCol &&
                   playerRow < n && playerRow >= 0 &&
                   playerCol < n && playerCol >= 0;
        }
    }
}

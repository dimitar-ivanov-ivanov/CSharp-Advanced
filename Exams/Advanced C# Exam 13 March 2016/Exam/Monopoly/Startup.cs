namespace Monopoly
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
            var n = int.Parse(args[0]);
            var m = int.Parse(args[1]);

            var matrix = new char[n, m];

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = line[j];
                }
            }

            var startCol = 0;
            var colVal = 1;
            var money = 50;
            var hotels = 0;
            var turns = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = startCol; j < m && j >= 0; j += colVal)
                {
                    switch (matrix[i, j])
                    {
                        case 'H':
                            hotels++;
                            Console.WriteLine($"Bought a hotel for {money}. Total hotels: {hotels}.");
                            money = 0;
                            break;
                        case 'S':
                            var moneyToSpend = (i + 1) * (j + 1);
                            if (moneyToSpend > money)
                            {
                                moneyToSpend = money;
                            }
                            money -= moneyToSpend;
                            Console.WriteLine($"Spent {moneyToSpend} money at the shop.");
                            break;
                        case 'J':
                            Console.WriteLine($"Gone to jail at turn {turns}.");
                            turns += 2;
                            money += 2 * hotels * 10;
                            break;
                        default:
                            break;
                    }

                    turns++;
                    money += hotels * 10;
                }

                colVal = -colVal;
                if (startCol == 0)
                {
                    startCol = m - 1;
                }
                else
                {
                    startCol = 0;
                }
            }

            Console.WriteLine($"Turns {turns}");
            Console.WriteLine($"Money {money}");
        }
    }
}
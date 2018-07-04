namespace ParkingSystem
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
            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var n = int.Parse(args[0]);
            var m = int.Parse(args[1]);

            var dict = new Dictionary<int, HashSet<int>>();
            args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            while (args[0] != "stop")
            {
                var entryRow = int.Parse(args[0]);
                var row = int.Parse(args[1]);
                var col = int.Parse(args[2]);
                var distance = Math.Abs(entryRow - row);

                if (!dict.ContainsKey(row))
                {
                    dict.Add(row, new HashSet<int>());
                }

                if (!dict[row].Contains(col))
                {
                    dict[row].Add(col);
                    distance += col + 1;
                    Console.WriteLine(distance);
                    args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    continue;
                }

                if (dict[row].Count == m - 1)
                {
                    Console.WriteLine($"Row {row} full");
                    args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    continue;
                }

                var left = 0;
                var right = 0;

                for (int i = col - 1; i > 0; i--)
                {
                    if (!dict[row].Contains(i))
                    {
                        left = i;
                        break;
                    }
                }
                for (int i = col + 1; i < m; i++)
                {
                    if (!dict[row].Contains(i))
                    {
                        right = i;
                        break;
                    }
                }

                if (left != 0 && right == 0)
                {
                    dict[row].Add(left);
                    distance += left + 1;
                }
                else if (left == 0 && right != 0)
                {
                    dict[row].Add(right);
                    distance += right + 1;
                }
                else if (col - left < right - col || col - left == right - col)
                {
                    dict[row].Add(left);
                    distance += left + 1;
                }
                else if (col - left > right - col)
                {
                    dict[row].Add(right);
                    distance += right + 1;
                }

                Console.WriteLine(distance);
                args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}

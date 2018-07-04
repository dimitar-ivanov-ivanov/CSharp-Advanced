using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingSystem
{
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
            var dict = new Dictionary<int, bool[]>();
            var rowFull = new Dictionary<int, bool>();
            var builder = new StringBuilder();
            args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            while (!string.Join(" ", args).Equals("stop"))
            {
                var z = int.Parse(args[0]);
                var x = int.Parse(args[1]);
                var y = int.Parse(args[2]);
                var distance = Math.Abs(z - y);

                if (!dict.ContainsKey(x))
                {
                    dict.Add(x, new bool[m]);
                    rowFull.Add(x, false);
                }

                if (rowFull[x])
                {
                    builder.AppendLine($"Row {x} full");
                }
                else if (!dict[x][y])
                {
                    dict[x][y] = true;
                    distance += y + 1;
                    builder.AppendLine(distance.ToString());

                }
                else if (dict[x][y])
                {
                    var left = -1; var right = -1;
                    for (int i = y - 1; i >= 0; i--)
                    {
                        if (!dict[x][i])
                        {
                            left = i;
                            break;
                        }
                    }
                    for (int i = y + 1; i < m; i++)
                    {
                        if (!dict[x][i])
                        {
                            right = i;
                            break;
                        }
                    }

                    if ((left == -1 || left == 0) && right == -1)
                    {
                        rowFull[x] = true;
                        builder.AppendLine($"Row {x} full");
                    }
                    else
                    {
                        if (y - left > right - y || left == 0)
                        {
                            dict[x][right] = true;
                            distance += right - y;
                        }
                        else if (y - left == right - y)
                        {
                            dict[x][left] = true;
                            distance += y - left;
                        }
                        else if (y - left < right - y)
                        {
                            dict[x][left] = true;
                            distance = y - left;
                        }

                        distance++;
                        builder.AppendLine(distance.ToString());
                    }
                }

                args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            return builder.ToString();
        }
    }
}
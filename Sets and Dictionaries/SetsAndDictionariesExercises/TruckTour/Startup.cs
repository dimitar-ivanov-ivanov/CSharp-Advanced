namespace TruckTour
{
    using System;
    using System.Collections.Generic;
    
    public class Startup
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            Console.WriteLine(Execute(n));
        }

        private static long Execute(int n)
        {
            var stations = new long[n, 2];
            var dp = new Dictionary<int, KeyValuePair<int, long>>();
            long gas = 0;
            var start = -1;
            var index = 0;
            string[] args;

            for (int i = 0; i < n; i++)
            {
                args = Console.ReadLine().Split(new[] { ' ' },
                       StringSplitOptions.RemoveEmptyEntries);
                stations[i, 0] = int.Parse(args[0]);
                stations[i, 1] = int.Parse(args[1]);
            }


            while (start != index)
            {
                if (dp.ContainsKey(index))
                {
                    gas += dp[index].Value;
                    index = dp[index].Key;
                    continue;
                }
                if (index == start)
                {
                    break;
                }

                gas += stations[index, 0];

                if (start == -1)
                {
                    start = index;
                }

                if (gas < 0)
                {
                    dp.Add(start, new KeyValuePair<int, long>(index, gas));
                    gas = 0;
                    start = -1;
                }

                index = (index + 1) % n;
            }


            return stations[start, 0];
        }
    }
}
namespace RecursiveFibonacci
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            Console.WriteLine(Execute(n));
        }

        private static long Execute(int n)
        {
            var dp = new long[n + 1];
            dp[1] = 1;
            dp[2] = 1;
            FindFib(n, dp);
            return dp[n];
        }

        private static long FindFib(int n, long[] dp)
        {
            if (dp[n] != 0)
            {
                return dp[n];
            }
            return dp[n] = FindFib(n - 1, dp) + FindFib(n - 2, dp);
        }
    }
}
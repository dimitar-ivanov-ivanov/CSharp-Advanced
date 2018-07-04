namespace CryptoMaster
{
    using System;
    using System.Linq;

    public class Startup
    {
        static int visited = -1001;

        public static void Main(string[] args)
        {
            var nums = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var dp = new int[nums.Length, nums.Length];
            dp[0, 0] = 1;
            var max = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = nums.Length - 1; j >= 1; j--)
                {
                    Rec(nums, dp, i, j, 1);
                    max = Math.Max(max, dp[i, j]);
                }
                max = Math.Max(max, dp[i, 0]);
            }

            Console.WriteLine(max);
        }

        private static int Rec(int[] nums, int[,] dp, int index, int step, int count)
        {
            var nextIndex = index - step;

            if (index - step < 0)
            {
                nextIndex = -nextIndex;
                nextIndex %= nums.Length;
                nextIndex = nums.Length - nextIndex;
            }

            if (nums[nextIndex] <= nums[index] || nums[index] == visited)
            {
                return count;
            }

            if (dp[nextIndex, step] != 0)
            {
                return dp[nextIndex, step];
            }

            var original = nums[index];
            nums[index] = visited;
            dp[index, step] = Rec(nums, dp, nextIndex, step, count + 1) + 1;
            nums[index] = original;
            return count;
        }
    }
}

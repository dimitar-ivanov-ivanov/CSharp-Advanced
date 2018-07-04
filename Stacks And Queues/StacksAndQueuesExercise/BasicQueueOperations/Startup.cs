namespace BasicQueueOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var commands = Console.ReadLine().Split(new[] { ' ' }
            , StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
            .ToArray();

            var nums = Console.ReadLine().Split(new[] { ' ' }
            , StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
            .ToArray();

            Console.WriteLine(Execute(commands, nums));
        }

        private static string Execute(int[] commands, int[] nums)
        {
            var queue = new Queue<int>();
            var n = commands[0];
            var s = commands[1];
            var x = commands[2];

            for (int i = 0; i < n && i < nums.Length; i++)
            {
                queue.Enqueue(nums[i]);
            }

            for (int i = 0; i < s && queue.Any(); i++)
            {
                queue.Dequeue();
            }

            if (!queue.Any())
            {
                return "0";
            }

            if (queue.Contains(x))
            {
                return "true";
            }

            return queue.Min().ToString();
        }
    }
}
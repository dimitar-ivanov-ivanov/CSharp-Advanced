namespace BasicStackOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        private static void Main(string[] args)
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
            var stack = new Stack<int>();
            var n = commands[0];
            var s = commands[1];
            var x = commands[2];

            for (int i = 0; i < n && i < nums.Length; i++)
            {
                stack.Push(nums[i]);
            }

            for (int i = 0; i < s && stack.Any(); i++)
            {
                stack.Pop();
            }

            if (!stack.Any())
            {
                return "0";
            }

            if (stack.Contains(x))
            {
                return "true";
            }

            return stack.Min().ToString();
        }
    }
}
namespace ArrayTest
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var n = int.Parse(Console.ReadLine());
            var nums = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse).ToArray();

            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            while (args[0] != "stop")
            {
                var command = args[0];
                switch (command)
                {
                    case "add":
                        var first = int.Parse(args[1]) - 1;
                        var second = int.Parse(args[2]);
                        nums[first] += second;
                        break;
                    case "subtract":
                        first = int.Parse(args[1]) - 1;
                        second = int.Parse(args[2]);
                        nums[first] -= second;
                        break;
                    case "multiply":
                        first = int.Parse(args[1]) - 1;
                        second = int.Parse(args[2]);
                        nums[first] *= second;
                        break;
                    case "rshift":
                        var lastNum = nums[nums.Length - 1];
                        for (int i = nums.Length - 1; i >= 1; i--)
                        {
                            nums[i] = nums[i - 1];
                        }
                        nums[0] = lastNum;
                        break;
                    case "lshift":
                        var firstNum = nums[0];
                        for (int i = 0; i < nums.Length - 1; i++)
                        {
                            nums[i] = nums[i + 1];
                        }
                        nums[nums.Length - 1] = firstNum;
                        break;
                    default:
                        break;
                }

                Console.WriteLine(string.Join(" ", nums));
                args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}

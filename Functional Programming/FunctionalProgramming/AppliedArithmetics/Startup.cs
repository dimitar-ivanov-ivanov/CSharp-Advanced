namespace AppliedArithmetics
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
            Action<int[]> print = x => Console.WriteLine(string.Join(" ", x));
            Func<int, int> add = x => x += 1;
            Func<int, int> multiply = x => x *= 2;
            Func<int, int> substract = x => x -= 1;

            var nums = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var line = Console.ReadLine();
            while (line != "end")
            {
                switch (line)
                {
                    case "add":
                        nums = nums.Select(x => add(x)).ToArray();
                        break;
                    case "multiply":
                        nums = nums.Select(x => multiply(x)).ToArray();
                        break;
                    case "subtract":
                        nums = nums.Select(x => substract(x)).ToArray();
                        break;
                    case "print":
                        print.Invoke(nums);
                        break;
                    default:
                        break;
                }
                line = Console.ReadLine();
            }
        }
    }
}

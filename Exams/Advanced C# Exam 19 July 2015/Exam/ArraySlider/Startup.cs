namespace ArraySlider
{
    using System;
    using System.Linq;
    using System.Numerics;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var nums = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(BigInteger.Parse)
                .ToArray();

            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            long index = 0;

            while (args[0] != "stop")
            {
                var offset = long.Parse(args[0]);
                var operation = args[1];
                var operand = long.Parse(args[2]);

                offset %= nums.Length;
                index += offset;
                index %= nums.Length;

                if (index < 0)
                {
                    index = nums.Length + index;
                }

                switch (operation)
                {
                    case "*":
                        nums[index] *= operand;
                        break;
                    case "+":
                        nums[index] += operand;
                        break;
                    case "-":
                        nums[index] -= operand;
                        break;
                    case "/":
                        nums[index] /= operand;
                        break;
                    case "&":
                        nums[index] &= operand;
                        break;
                    case "|":
                        nums[index] |= operand;
                        break;
                    case "^":
                        nums[index] ^= operand;
                        break;
                    default:
                        break;
                }

                if (nums[index] < 0)
                {
                    nums[index] = 0;
                }
                args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine("[" + string.Join(", ", nums) + "]");
        }
    }
}

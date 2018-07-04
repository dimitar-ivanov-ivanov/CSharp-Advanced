namespace FindEvenOrOdd
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var nums = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();
            var direction = Console.ReadLine();
            var predicate = new Predicate<int>(x => x % 2 == 0);
            var res = new List<int>();

            for (int i = nums[0]; i <= nums[1]; i++)
            {
                if (direction == "odd" && !predicate.Invoke(i))
                {
                    res.Add(i);
                }
                else if (direction == "even" && predicate.Invoke(i))
                {
                    res.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", res));
        }
    }
}

namespace CustomComparator
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
            Predicate<int> isEven = n => n % 2 == 0;
            Func<string, int> parser = n => int.Parse(n);
            var nums = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .GroupBy(n => isEven(n))
                .OrderByDescending(g => g.Key)
                .ToDictionary(g => g.Key, g => g.OrderBy(x => x).ToList());

            foreach (var group in nums)
            {
                Console.Write(string.Join(" ", group.Value) + " ");
            }
            Console.WriteLine();
        }
    }
}

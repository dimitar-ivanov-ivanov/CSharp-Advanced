namespace BoundedNumbers
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Execute());
        }

        private static string Execute()
        {
            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var lowerBound = int.Parse(args[0]);
            var upperBound = int.Parse(args[1]);

            var l = Math.Min(lowerBound, upperBound);
            var u = Math.Max(lowerBound, upperBound);

            var nums = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(a => a >= l && a <= u)
                .ToArray();

            return string.Join(" ", nums);
        }
    }
}

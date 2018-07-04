namespace TakeTwo
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
            var nums = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(s => s >= 10 && s <= 20)
                .Distinct()
                .Take(2)
                .ToArray();

            return string.Join(" ", nums);
        }
    }
}

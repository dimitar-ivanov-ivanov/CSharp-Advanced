namespace SortEvenNumbers
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
            Func<int, bool> isEven = n => n % 2 == 0;
            var arr = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(isEven)
                .ToArray();
            Console.WriteLine(string.Join(", ", arr.OrderBy(x => x)));
        }
    }
}

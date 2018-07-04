namespace ReverseAndExclude
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
            Func<string, int> parser = x => int.Parse(x);
            var nums = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(parser)
                .ToList();

            var divNum = int.Parse(Console.ReadLine());
            Predicate<int> predicate = x => x % divNum == 0;
            nums.Reverse();
            var res = nums.RemoveAll(x => predicate.Invoke(x));
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
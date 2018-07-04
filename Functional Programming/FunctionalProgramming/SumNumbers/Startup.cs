namespace SumNumbers
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
            Func<string, int> parser = n => int.Parse(n);
            var first = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(parser)
                .ToArray();

            Console.WriteLine(first.Length);
            Console.WriteLine(first.Sum());
        }
    }
}

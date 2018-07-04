namespace ReverseNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            Console.WriteLine(Execute(input));
        }

        private static string Execute(int[] input)
        {
            var stack = new Stack<int>(input);
            return String.Join(" ", stack);
        }
    }
}
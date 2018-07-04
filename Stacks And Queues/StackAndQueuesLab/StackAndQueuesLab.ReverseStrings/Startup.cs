namespace ReverseStrings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ReverseStrings
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            Console.WriteLine(Execute(input));
        }

        private static string Execute(string input)
        {
            var stack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(input[i]);
            }

            var reverseString = new StringBuilder();
            while (stack.Any())
            {
                reverseString.Append(stack.Pop());
            }

            return reverseString.ToString();
        }
    }
}

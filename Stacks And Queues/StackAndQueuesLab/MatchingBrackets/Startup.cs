namespace MatchingBrackets
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            Console.WriteLine(Execute(input));
        }

        private static string Execute(string input)
        {
            var res = new StringBuilder();
            var stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                }
                else if (input[i] == ')')
                {
                    var opening = stack.Pop();
                    var expression = input.Substring(opening, i - opening + 1);
                    res.AppendLine(expression);
                }
            }

            return res.ToString().Trim();
        }
    }
}

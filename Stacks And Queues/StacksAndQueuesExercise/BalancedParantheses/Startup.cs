namespace BalancedParantheses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            Console.WriteLine(Execute(input));
        }

        private static string Execute(string input)
        {
            var stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                var top = 0;
                switch (input[i])
                {
                    case '{':
                    case '(':
                    case '[':
                        stack.Push(i);
                        break;
                    case '}':
                        if (!stack.Any())
                        {
                            return "NO";
                        }
                        top = stack.Peek();
                        if (input[top] != '{')
                        {
                            return "NO";
                        }
                        stack.Pop();
                        break;
                    case ']':
                        if (!stack.Any())
                        {
                            return "NO";
                        }
                        top = stack.Peek();
                        if (input[top] != '[')
                        {
                            return "NO";
                        }
                        stack.Pop();
                        break;
                    case ')':
                        if (!stack.Any())
                        {
                            return "NO";
                        }
                        top = stack.Peek();
                        if (input[top] != '(')
                        {
                            return "NO";
                        }
                        stack.Pop();
                        break;
                    default:
                        break;
                }
            }

            return "YES";
        }
    }
}

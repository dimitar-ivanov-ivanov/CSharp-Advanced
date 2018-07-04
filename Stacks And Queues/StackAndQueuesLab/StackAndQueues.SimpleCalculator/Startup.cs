namespace SimpleCalculator
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            Console.WriteLine(Execute(input));
        }

        private static int Execute(string input)
        {
            var args = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var stack = new Stack<int>();
            stack.Push(int.Parse(args[0]));

            for (int i = 1; i < args.Length; i += 2)
            {
                var num = int.Parse(args[i + 1]);
                if (args[i] == "-")
                {
                    num = -num;
                }

                stack.Push(stack.Pop() + num);
            }

            return stack.Pop();
        }
    }
}

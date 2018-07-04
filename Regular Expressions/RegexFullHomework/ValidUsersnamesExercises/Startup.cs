namespace ValidUsersnamesExercises
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Execute());
        }

        private static string Execute()
        {
            var regex = new Regex(@"^[a-zA-Z][\w]{2,24}$");
            var separators = new char[] { ' ', '\\', '/', '(', ')' };
            var maxSum = 0;
            var args = Console.ReadLine()
                .Split(separators, StringSplitOptions.RemoveEmptyEntries);
            var first = string.Empty;
            var second = string.Empty;
            var matches = new List<string>();

            for (int i = 0; i < args.Length; i++)
            {
                if (regex.IsMatch(args[i]))
                {
                    matches.Add(args[i]);
                }
            }

            for (int i = 0; i < matches.Count - 1; i++)
            {
                var currentSum = matches[i].Length + matches[i + 1].Length;
                if (currentSum > maxSum)
                {
                    first = matches[i];
                    second = matches[i + 1];
                    maxSum = currentSum;
                }
            }

            return first + "\n" + second;
        }
    }
}
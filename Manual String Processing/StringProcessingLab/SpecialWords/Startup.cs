namespace SpecialWords
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Execute());
        }

        private static string Execute()
        {
            var builder = new StringBuilder();
            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var dict = new Dictionary<string, int>();

            for (int i = 0; i < args.Length; i++)
            {
                dict.Add(args[i], 0);
            }

            var input = Console.ReadLine()
                .Split(new[] { ' ', '(', ')', '[', ']', '<', '>', ',', '-', '!', '?' }
                , StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i++)
            {
                if (dict.ContainsKey(input[i]))
                {
                    dict[input[i]]++;
                }
            }

            foreach (var word in dict)
            {
                builder.AppendLine($"{word.Key} - {word.Value}");
            }

            return builder.ToString();
        }
    }
}

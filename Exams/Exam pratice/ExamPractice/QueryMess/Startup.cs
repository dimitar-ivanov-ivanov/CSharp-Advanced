namespace QueryMess
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var regex = new Regex("(\\+|%20)+");
            var input = Console.ReadLine();
            var builder = new StringBuilder();

            while (input != "END")
            {
                var pairs = new Dictionary<string, List<string>>();
                input = regex.Replace(input, " ");
                var args = input.Split(new[] { '&', '?' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < args.Length; i++)
                {
                    if (!args[i].Contains("="))
                    {
                        continue;
                    }

                    var split = args[i].Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                    var key = split[0].Trim();

                    if (!pairs.ContainsKey(key))
                    {
                        pairs.Add(key, new List<string>());
                    }
                    pairs[key].Add(split[1].Trim());
                }

                foreach (var pair in pairs)
                {
                    builder.Append($"{pair.Key}=[{string.Join(", ", pair.Value)}]");
                }
                builder.AppendLine();

                input = Console.ReadLine();
            }

            Console.WriteLine(builder.ToString());
        }
    }
}

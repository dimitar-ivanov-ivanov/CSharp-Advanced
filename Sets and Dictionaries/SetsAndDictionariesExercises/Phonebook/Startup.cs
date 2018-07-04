namespace Phonebook
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
            var args = Console.ReadLine().Split(new[] { ' ', '-' },
                StringSplitOptions.RemoveEmptyEntries);

            var phonebook = new Dictionary<string, string>();

            while (args[0] != "search")
            {
                if (!phonebook.ContainsKey(args[0]))
                {
                    phonebook.Add(args[0], args[1]);
                }
                else
                {
                    phonebook[args[0]] = args[1];
                }

                args = Console.ReadLine().Split(new[] { ' ', '-' },
                StringSplitOptions.RemoveEmptyEntries);
            }

            var res = new StringBuilder();
            var name = Console.ReadLine();

            while (name != "stop")
            {
                if (phonebook.ContainsKey(name))
                {
                    res.AppendLine($"{name} -> {phonebook[name]}");
                }
                else
                {
                    res.AppendLine($"Contact {name} does not exist.");
                }

                name = Console.ReadLine();
            }

            return res.ToString();
        }
    }
}

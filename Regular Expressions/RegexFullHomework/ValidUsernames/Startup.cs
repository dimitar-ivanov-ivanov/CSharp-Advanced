namespace ValidUsernames
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Execute());
        }

        private static string Execute()
        {
            var output = new StringBuilder();
            var usernames = new List<string>();
            var regex = new Regex(@"^(?:([\w-]){3,16}(?!.*\1))$");

            var input = Console.ReadLine();
            while (input != "END")
            {
                usernames.Add(input);
                input = Console.ReadLine();
            }

            foreach (var name in usernames)
            {
                if (regex.IsMatch(name))
                {
                    output.AppendLine("valid");
                }
                else
                {
                    output.AppendLine("invalid");
                }
            }

            return output.ToString();
        }
    }
}
namespace FixEmails
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
            var name = Console.ReadLine();
            var users = new Dictionary<string, string>();
            var res = new StringBuilder();

            while (name != "stop")
            {
                var email = Console.ReadLine();
                if (!(email.EndsWith("us") || email.EndsWith("uk") ||
                      email.EndsWith("US") || email.EndsWith("UK")))
                {
                    users.Add(name, email);
                }

                name = Console.ReadLine();
            }

            foreach (var user in users)
            {
                res.AppendLine($"{user.Key} -> {user.Value}");
            }

            return res.ToString();
        }
    }
}
namespace Valid_Usernames
{
    using System;
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
            var regex = new Regex(@"^[\w-]{3,16}$");
            var input = new StringBuilder();
            var output = new StringBuilder();
            var line = Console.ReadLine();

            while (line != "END")
            {
                if (!regex.IsMatch(line))
                {
                    output.AppendLine("invalid");
                }
                else
                {
                    output.AppendLine("valid");
                }

                line = Console.ReadLine();
            }

            return output.ToString();
        }
    }
}
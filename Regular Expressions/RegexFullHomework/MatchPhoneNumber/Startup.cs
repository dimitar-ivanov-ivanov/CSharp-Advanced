namespace MatchPhoneNumber
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
            var regex = new Regex(@"\+359(?<sep>(-| ))2\k<sep>\d{3}\k<sep>\d{4}");
            var line = Console.ReadLine();
            var output = new StringBuilder();

            while (line != "end")
            {
                if (regex.IsMatch(line))
                {
                    output.AppendLine(line);
                }
                line = Console.ReadLine();
            }

            return output.ToString();
        }
    }
}

namespace Valid_Time
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
            var regex = new Regex(@"^(\d{2}):(\d{2}):(\d{2}) (PM|AM)$");
            var output = new StringBuilder();
            var line = Console.ReadLine();

            while (line != "END")
            {
                if (regex.IsMatch(line))
                {
                    var match = regex.Matches(line)[0];
                    var h = int.Parse(match.Groups[1].Value);
                    var m = int.Parse(match.Groups[2].Value);
                    var s = int.Parse(match.Groups[3].Value);

                    if (h < 0 || h > 11 ||
                       m < 0 || m > 59 ||
                       s < 0 || s > 59)
                    {
                        output.AppendLine("invalid");
                    }
                    else
                    {
                        output.AppendLine("valid");
                    }
                }
                else
                {
                    output.AppendLine("invalid");
                }

                line = Console.ReadLine();
            }

            return output.ToString();
        }
    }
}
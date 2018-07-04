namespace ValidTime
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
            var times = new List<string>();
            var regex = new Regex(@"^(?:(\d{2}):(\d{2}):(\d{2}) (PM|AM)(?!.*\1))$");

            var input = Console.ReadLine();
            while (input != "END")
            {
                times.Add(input);
                input = Console.ReadLine();
            }

            foreach (var time in times)
            {
                if (regex.IsMatch(time))
                {
                    var match = regex.Match(time);
                    var hour = int.Parse(match.Groups[1].Value);
                    var minute = int.Parse(match.Groups[2].Value);
                    var second = int.Parse(match.Groups[3].Value);

                    if (hour < 0 || hour > 11 ||
                        minute < 0 || minute > 59 ||
                        second < 0 || second > 59)
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
            }

            return output.ToString();
        }
    }
}
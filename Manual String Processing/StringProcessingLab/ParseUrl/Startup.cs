namespace ParseUrl
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            Console.WriteLine(Execute(input));
        }

        private static string Execute(string input)
        {
            var regex = new Regex(@"^(?<protocol>\w+)(:\/\/)(?<server>[\w.]+)\/(?<resource>[\w\/-]+)$");
            var match = regex.Match(input);
            if (match.Length != 0)
            {
                var protocol = match.Groups["protocol"].Value;
                var server = match.Groups["server"].Value;
                var resource = match.Groups["resource"].Value;

                return $"Protocol = {protocol}\nServer = {server}\nResources = {resource}";
            }
            else
            {
                return "Invalid URL";
            }
        }
    }
}

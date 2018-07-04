namespace MatchCount
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Execute());
        }

        private static int Execute()
        {
            var key = Console.ReadLine();
            var input = Console.ReadLine();
            var regex = new Regex(key);
            var matches = regex.Matches(input);
            return matches.Count;
        }
    }
}

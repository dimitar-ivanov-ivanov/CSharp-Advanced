namespace VowelCount
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Execute());
        }

        private static string Execute()
        {
            var input = Console.ReadLine();
            var regex = new Regex("[aeiouyAEIOUY]");
            var matches = regex.Matches(input);
            return "Vowels: " + matches.Count;
        }
    }
}
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

        private static String Execute()
        {
            var input = Console.ReadLine();
            var regex = new Regex("[aieouyAIEOUY]");
            var matches = regex.Matches(input);
            return $"Vowels: {matches.Count}";
        }
    }
}

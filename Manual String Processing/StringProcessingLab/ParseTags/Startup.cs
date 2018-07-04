namespace ParseTags
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            Console.WriteLine(Execute(input));
        }

        private static string Execute(string input)
        {
            var first = input.IndexOf("<upcase>");
            var second = input.IndexOf("</upcase>");

            while (first != -1 && second != -1)
            {
                var word = input.Substring(first + 8, second - first - 8);
                input = input.Remove(first + 8, word.Length);
                input = input.Insert(first + 8, word.ToUpper());
                input = input.Remove(first, 8);
                input = input.Remove(second - 8, 9);

                first = input.IndexOf("<upcase>");
                second = input.IndexOf("</upcase>");
            }

            return input;
        }
    }
}

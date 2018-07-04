namespace UnicodeCharacters
{
    using System;
    using System.Text;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Execute());
        }

        private static string Execute()
        {
            var input = Console.ReadLine();
            var builder = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                builder.Append("\\u" + ((int)input[i]).ToString("X4").ToLower());
            }

            return builder.ToString();
        }
    }
}


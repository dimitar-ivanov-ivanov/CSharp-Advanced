namespace ReverseString
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
            for (int i = input.Length - 1; i >= 0; i--)
            {
                builder.Append(input[i]);
            }

            return builder.ToString();
        }
    }
}
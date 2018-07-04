namespace ConcatenateStrings
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
            var n = int.Parse(Console.ReadLine());
            var builder = new StringBuilder();

            for (int i = 0; i < n; i++)
            {

                builder.Append(Console.ReadLine() + " ");
            }

            return builder.ToString();
        }
    }
}

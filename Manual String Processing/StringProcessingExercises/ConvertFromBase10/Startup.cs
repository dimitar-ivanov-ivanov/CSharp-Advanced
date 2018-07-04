namespace ConvertFromBase10
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
            var args = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var n = byte.Parse(args[0]);
            var number = int.Parse(args[1]);
            var builder = new StringBuilder();

            if (n == 10)
            {
                return number.ToString();
            }

            while (number != 0)
            {
                builder.Append(number % n);
                number = number / n;
            }

            var result = builder.ToString().ToCharArray();
            Array.Reverse(result);
            return new string(result);
        }
    }
}

namespace ConvertFromNTo10
{
    using System;
    using System.Numerics;
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
            var number = args[1];
            var builder = new StringBuilder();

            BigInteger result = 0;

            for (int i = 0; i < number.Length; i++)
            {
                result += (number[i] - '0') *
                    BigInteger.Pow(n, number.Length - i - 1);
            }

            return result.ToString();
        }
    }
}

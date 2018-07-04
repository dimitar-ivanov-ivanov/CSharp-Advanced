namespace LettersChangeNumbers
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            //up -  divide,substract
            //lower - multiply,add
            Console.WriteLine($"{Execute():f2}");
        }

        private static double Execute()
        {
            var args = Console.ReadLine().Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            double res = 0;

            for (int i = 0; i < args.Length; i++)
            {
                var input = args[i];
                var first = input[0];
                var second = input[input.Length - 1];
                var sum = double.Parse(input.Substring(1, input.Length - 2));

                if (char.IsUpper(first))
                {
                    sum /= (26 - ('Z' - first));
                }
                else if (char.IsLower(first))
                {
                    sum *= (26 - ('z' - first));
                }

                if (char.IsUpper(second))
                {
                    sum -= (26 - ('Z' - second));
                }
                else if (char.IsLower(second))
                {
                    sum += (26 - ('z' - second));
                }
                res += sum;
            }

            return res;
        }
    }
}
namespace DecimalBinaryConverter
{
    using System;
    using System.Collections.Generic;

    public class DecimalBinaryConverter
    {
        public static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());
            Console.WriteLine(Execute(num));
        }

        private static string Execute(int num)
        {
            if (num == 0)
            {
                return "0";
            }

            var stack = new Stack<int>();
            while (num != 0)
            {
                var remainder = num % 2;
                num /= 2;
                stack.Push(remainder);
            }

            return string.Join("", stack);
        }
    }
}
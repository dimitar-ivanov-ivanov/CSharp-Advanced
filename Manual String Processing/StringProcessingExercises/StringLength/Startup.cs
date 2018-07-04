namespace StringLength
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Execute());
        }

        private static string Execute()
        {
            var input = Console.ReadLine();
            input = input.PadRight(20, '*');
            return input;
        }
    }
}

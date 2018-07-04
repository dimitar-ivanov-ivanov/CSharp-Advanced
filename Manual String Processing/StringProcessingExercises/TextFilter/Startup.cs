namespace TextFilter
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
            var args = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            var input = Console.ReadLine();
            for (int i = 0; i < args.Length; i++)
            {
                input = input.Replace(args[i], new string('*', args[i].Length));
            }

            return input;
        }
    }
}

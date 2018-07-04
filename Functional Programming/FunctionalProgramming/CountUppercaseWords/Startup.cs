namespace CountUppercaseWords
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            Func<string, bool> isUpper = n => char.IsUpper(n[0]);
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(isUpper);

            Console.WriteLine(string.Join("\n", input));
        }
    }
}

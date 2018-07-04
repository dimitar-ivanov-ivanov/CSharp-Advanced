namespace PredicateNames
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
            var n = int.Parse(Console.ReadLine());
            Func<string, bool> lengthCheck = x => x.Length <= n;
            var res = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(lengthCheck);

            Console.WriteLine(string.Join("\n", res));
        }
    }
}

namespace ActionPrint
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
            Action<string> act = n => Console.WriteLine(n);
            var list = Console.ReadLine()
             .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
             .ToList();
            list.ForEach(act);
        }
    }
}
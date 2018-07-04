namespace Custom_Min_Function
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
            Func<int[], int> min = n => n.Min();
            Func<string, int> parser = n => int.Parse(n);
            var arr = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(parser)
                .ToArray();
            Console.WriteLine(min.Invoke(arr));
        }
    }
}

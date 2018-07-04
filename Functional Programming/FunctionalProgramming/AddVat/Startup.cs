namespace AddVat
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Func<String, double> parser = n => double.Parse(n);
            Func<double, double> addVat = n => n + n * 20 / 100;
            Func<double, string> output = n => $"{n:f2}";

            var input = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(parser)
                .Select(addVat)
                .Select(output);

            Console.WriteLine(string.Join("\n", input));
        }
    }
}

namespace AverageOfDoubles
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Console.WriteLine($"{Execute():f2}");
        }

        private static double Execute()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var res = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray()
                .Average();

            return res;
        }
    }
}

namespace StudentResults
{
    using System;
    using System.Globalization;
    using System.Text;
    using System.Threading;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Execute());
        }

        private static string Execute()
        {
            var n = int.Parse(Console.ReadLine());
            var builder = new StringBuilder();
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            builder.AppendLine("Name      |   CAdv|   COOP| AdvOOP|Average|");

            for (int i = 0; i < n; i++)
            {
                var args = Console.ReadLine()
                    .Split(new[] { ' ', ',', '-' },
                    StringSplitOptions.RemoveEmptyEntries);

                var name = args[0];

                var cAdv = decimal.Parse(args[1]);
                var cOop = decimal.Parse(args[2]);
                var advOop = decimal.Parse(args[3]);

                var avg = (cAdv + cOop + advOop) / 3;
                builder.AppendLine($"{name,-10}|   {cAdv:f2}|   {cOop:f2}|   {advOop:f2}| {avg:f4}|");
            }

            return builder.ToString();
        }
    }
}

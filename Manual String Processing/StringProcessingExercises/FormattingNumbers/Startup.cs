namespace FormattingNumbers
{
    using System;
    using System.Globalization;
    using System.Threading;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Execute());
        }

        private static string Execute()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var args = Console.ReadLine().Split(new[] { ' ', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            var a = int.Parse(args[0]);
            var b = double.Parse(args[1]);
            var c = double.Parse(args[2]);

            var binary = Convert.ToString(a, 2);
            if (binary.Length > 10) { binary = binary.Remove(11); }
            else if (binary.Length < 10) { binary = new string('0', 10 - binary.Length) + binary; }

            return string.Format("|{0,-10}|{1}|{2,10:F2}|{3,-10:F3}| ", a.ToString("X"), binary, b, c);
        }
    }
}

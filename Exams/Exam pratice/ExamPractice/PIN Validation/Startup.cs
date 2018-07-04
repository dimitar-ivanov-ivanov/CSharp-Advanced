namespace PIN_Validation
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var regex = new Regex("\\d{10}");
            var nameRegex = new Regex("[A-Z][a-z]+ [A-Z][a-z]+");

            var name = Console.ReadLine();
            var gender = Console.ReadLine();
            var pin = Console.ReadLine();

            if (!regex.IsMatch(pin))
            {
                Console.WriteLine("<h2>Incorrect data</h2>");
                return;
            }

            if (!nameRegex.IsMatch(name))
            {
                Console.WriteLine("<h2>Incorrect data</h2>");
                return;
            }

            var y = int.Parse(pin.Substring(0, 2));
            var m = int.Parse(pin.Substring(2, 2));
            var d = int.Parse(pin.Substring(4, 2));

            if (y == 0 || m == 0 || d == 0 || m > 52 ||
               (m > 32 && m < 41))
            {
                Console.WriteLine("<h2>Incorrect data</h2>");
                return;
            }

            var genderDigit = int.Parse(pin.Substring(8, 1));
            var multiplier = new int[] { 2, 4, 8, 5, 10, 9, 7, 3, 6 };
            var sum = 0;

            if ((genderDigit % 2 == 0 && gender == "female") ||
                (genderDigit % 2 != 0 && gender == "male"))
            {
                Console.WriteLine("<h2>Incorrect data</h2>");
                return;
            }

            for (int i = 0; i < pin.Length - 1; i++)
            {
                sum += (pin[i] - '0') * multiplier[i];
            }

            var remainder = sum % 11;
            if (remainder == 10)
            {
                remainder = 0;
            }

            var lastDigit = pin[9] - '0';
            if (lastDigit != remainder)
            {
                Console.WriteLine("<h2>Incorrect data</h2>");
                return;
            }

            Console.WriteLine($"{{\"name\":\"{name}\",\"gender\":\"{gender}\",\"pin\":\"{pin}\"}}");
        }
    }
}
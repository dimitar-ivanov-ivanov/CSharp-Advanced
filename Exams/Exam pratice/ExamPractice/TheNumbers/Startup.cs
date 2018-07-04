namespace TheNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var regex = new Regex("\\d+");
            var line = Console.ReadLine();

            var matches = regex.Matches(line);
            var list = new List<string>();

            foreach (Match m in matches)
            {
                string hexValue = int.Parse(m.Value).ToString("X");
                if (hexValue.Length < 4)
                {
                    hexValue = hexValue.PadLeft(4, '0');
                }

                hexValue = "0x" + hexValue;
                list.Add(hexValue);
            }

            Console.WriteLine(string.Join("-", list));
        }
    }
}

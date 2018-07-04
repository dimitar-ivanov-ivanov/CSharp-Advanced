using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Non_Digit_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Execute());
        }

        private static string Execute()
        {
            var input = Console.ReadLine();
            var regex = new Regex("\\D");
            var matches = regex.Matches(input);
            return $"Non-digits: {matches.Count}";
        }
    }
}

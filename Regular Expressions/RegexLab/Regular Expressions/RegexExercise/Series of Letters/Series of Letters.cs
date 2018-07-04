using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Series_of_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Execute());
        }

        private static string Execute()
        {
            var regex = new Regex(@"(.)\1+");
            var output = new StringBuilder();
            var line = Console.ReadLine();
            return regex.Replace(line, "$1");        
        }
    }
}

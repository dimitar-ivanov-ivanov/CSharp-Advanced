using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem_2.Match_Phone_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Execute());
        }

        private static string Execute()
        {
            var regex = new Regex(@"^\+359(?<separator>( |-))2\k<separator>\d{3}\k<separator>\d{4}$");
            var output = new StringBuilder();
            var line = Console.ReadLine();

            while(line != "end")
            {
                if (regex.IsMatch(line))
                {
                    output.AppendLine(line);
                }
                line = Console.ReadLine();
            }

            return output.ToString();
        }
    }
}

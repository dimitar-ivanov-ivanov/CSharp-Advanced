using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MatchFullName
{
    class MatchFullName
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Execute());
        }

        private static string Execute()
        {
            var regex = new Regex("^[A-Z][a-z]{1,} [A-Z][a-z]{1,}$");
            var line = Console.ReadLine();
            var output = new StringBuilder();

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

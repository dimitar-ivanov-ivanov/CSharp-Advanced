using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Extract_Quotations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Execute());
        }

        private static string Execute()
        {
            var regex = new Regex("(?<quote>['\"])(?<content>.+?)\\k<quote>");
            var input = Console.ReadLine();
            var matches = regex.Matches(input);
            var output = new StringBuilder();

            foreach (Match m in matches)
            {
                output.AppendLine(m.Groups["content"].Value);
            }

            return output.ToString();
        }
    }
}

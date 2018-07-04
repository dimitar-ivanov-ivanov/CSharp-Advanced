using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Extract_Tags
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Execute());
        }

        private static string Execute()
        {
            var regex = new Regex(@"<(.+?)>");
            var builder = new StringBuilder();
            var input = Console.ReadLine();
            var output = new StringBuilder();

            while(input != "END")
            {
                builder.AppendLine(input);
                input = Console.ReadLine();
            }

            var matches = regex.Matches(builder.ToString());
            foreach (Match m in matches)
            {
                output.AppendLine(m.Value);
            }

            return output.ToString();
        }
    }
}

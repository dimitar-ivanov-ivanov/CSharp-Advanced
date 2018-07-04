using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MatchCount
{
    class MatchCount
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Execute());
        }

        private static int Execute()
        {
            var key = Console.ReadLine();
            var input = Console.ReadLine();
            var regex = new Regex(key);
            var matches = regex.Matches(input);
            return matches.Count;
        }
    }
}

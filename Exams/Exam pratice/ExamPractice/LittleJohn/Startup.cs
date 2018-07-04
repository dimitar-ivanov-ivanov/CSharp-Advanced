namespace LittleJohn
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var small = ">----->";
            var medium = ">>----->";
            var large = ">>>----->>";

            var list = new List<string>();
            var n = 4;
            for (int i = 0; i < n; i++)
            {
                list.Add(Console.ReadLine());
            }

            var largeNum = RemoveMatches(list, large);
            var mediumNum = RemoveMatches(list, medium);
            var smallNum = RemoveMatches(list, small);

            var sum = int.Parse(smallNum + mediumNum + largeNum);
            var binarySum = Convert.ToString(sum, 2);
            var reverseBinary = new string(binarySum.Reverse().ToArray());
            var fullBinary = binarySum + reverseBinary;
            var res = Convert.ToInt64(fullBinary, 2).ToString();
            Console.WriteLine(res);
        }

        private static string RemoveMatches(List<string> list, string arrow)
        {
            var res = 0;
            var regex = new Regex(arrow);
            for (int i = 0; i < list.Count; i++)
            {
                var matches = regex.Matches(list[i]);
                list[i] = regex.Replace(list[i], "");
                res += matches.Count;
            }

            return res.ToString();
        }
    }
}

namespace MagicExchangeableWords
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Execute().ToString().ToLower());
        }

        private static bool Execute()
        {
            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var first = args[0];
            var second = args[1];

            var firstDict = new Dictionary<char, char>();
            var secondDict = new Dictionary<char, char>();

            var minLen = Math.Min(first.Length, second.Length);

            for (int i = 0; i < minLen; i++)
            {
                var c1 = first[i];
                var c2 = second[i];

                if ((firstDict.ContainsKey(c1) && firstDict[c1] != c2) ||
                    (secondDict.ContainsKey(c2) && secondDict[c2] != c1))
                {
                    return false;
                }

                if (!firstDict.ContainsKey(c1))
                {
                    firstDict.Add(c1, c2);
                }

                if (!secondDict.ContainsKey(c2))
                {
                    secondDict.Add(c2, c1);
                }
            }

            if (first.Length != second.Length)
            {
                var longestStr = first.Length > second.Length ? first : second;

                for (int i = minLen; i < longestStr.Length; i++)
                {
                    var c = longestStr[i];
                    if (longestStr == second)
                    {
                        if (!secondDict.ContainsKey(c))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (!firstDict.ContainsKey(c))
                        {
                            return false;
                        }
                    }
                }
            }


            return true;
        }
    }
}

namespace CharacterMultiplier
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Execute());
        }

        private static long Execute()
        {
            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var first = args[0];
            var second = args[1];
            var minLen = Math.Min(first.Length, second.Length);
            long res = 0;

            for (int i = 0; i < minLen; i++)
            {
                res += first[i] * second[i];
            }

            if (first.Length != second.Length)
            {
                var longestStr = first.Length > second.Length ? first :
                    second;

                for (int i = minLen; i < longestStr.Length; i++)
                {
                    res += longestStr[i];
                }
            }

            return res;
        }
    }
}
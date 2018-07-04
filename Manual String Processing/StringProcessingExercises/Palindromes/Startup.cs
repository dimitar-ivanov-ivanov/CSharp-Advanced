namespace Palindromes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Execute());
        }

        private static string Execute()
        {
            var input = Console.ReadLine()
                .Split(new[] { ' ', ',', '!', '.', '?' }, StringSplitOptions.RemoveEmptyEntries);
            var res = new HashSet<string>();

            for (int i = 0; i < input.Length; i++)
            {
                var word = input[i];
                var isPalindrome = true;

                for (int j = 0, k = word.Length - 1; j < k; j++, k--)
                {
                    if (word[j] != word[k])
                    {
                        isPalindrome = false;
                        break;
                    }
                }

                if (isPalindrome)
                {
                    res.Add(word);
                }
            }

            return $"[{string.Join(", ", res.OrderBy(x => x))}]";
        }
    }
}

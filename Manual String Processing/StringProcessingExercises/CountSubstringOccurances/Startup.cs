namespace CountSubstringOccurances
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Execute());
        }

        private static int Execute()
        {
            var text = Console.ReadLine();
            var key = Console.ReadLine().ToLower();

            var res = 0;
            for (int i = 0; i <= text.Length - key.Length; i++)
            {
                var sub = text.Substring(i, key.Length).ToLower();
                if (sub == key)
                {
                    res++;
                }
            }

            return res;
        }
    }
}

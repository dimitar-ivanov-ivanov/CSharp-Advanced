namespace SumIntegers
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
            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var nums = new List<int>();
            for (int i = 0; i < args.Length; i++)
            {
                var val = 0;
                if (int.TryParse(args[i], out val))
                {
                    nums.Add(val);
                }
            }

            if (nums.Count == 0)
            {
                return "No match";
            }

            return nums.Sum().ToString();
        }
    }
}

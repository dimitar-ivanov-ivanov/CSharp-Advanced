namespace Group_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Execute());
        }

        private static string Execute()
        {
            var nums = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var remainders = new List<int>[3];
            var builder = new StringBuilder();
            for (int i = 0; i < remainders.Length; i++)
            {
                remainders[i] = new List<int>();
            }

            for (int i = 0; i < nums.Length; i++)
            {
                remainders[Math.Abs(nums[i] % 3)].Add(nums[i]);
            }

            for (int i = 0; i < remainders.Length; i++)
            {
                for (int j = 0; j < remainders[i].Count; j++)
                {
                    builder.Append(remainders[i][j] + " ");
                }
                if (builder.Length != 0)
                {
                    builder = builder.Remove(builder.Length - 1, 1);
                }
                builder.AppendLine();
            }

            if (builder.Length != 0)
            {
                builder = builder.Remove(builder.Length - 1, 1);
            }

            return builder.ToString();
        }
    }
}
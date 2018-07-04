namespace BePositive
{
    using System;
    using System.Linq;
    using System.Text;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var n = int.Parse(Console.ReadLine());
            var builder = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                var nums = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var count = 0;

                for (int j = 0; j < nums.Length; j++)
                {
                    var currentNum = nums[j];
                    if (currentNum >= 0)
                    {
                        builder.Append(currentNum + " ");
                        count++;
                    }
                    else
                    {
                        if (j + 1 < nums.Length)
                        {
                            currentNum += nums[j + 1];
                            j++;
                            if (currentNum >= 0)
                            {
                                builder.Append(currentNum + " ");
                            }
                        }
                    }
                }

                if (count == 0)
                {
                    builder.Append("(empty)");
                }
                builder.AppendLine();
            }

            Console.WriteLine(builder);
        }
    }
}

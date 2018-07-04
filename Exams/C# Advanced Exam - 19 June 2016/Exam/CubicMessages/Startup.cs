namespace CubicMessages
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var line = Console.ReadLine();
            var m = int.Parse(Console.ReadLine());
            var regex = new Regex(@"^(\d+)([a-zA-Z]+)([^a-zA-Z]*)$");

            while (true)
            {
                if (!regex.IsMatch(line))
                {
                    line = Console.ReadLine();
                    if (line == "Over!")
                    {
                        break;
                    }
                    m = int.Parse(Console.ReadLine());
                    continue;
                }

                var match = regex.Match(line);
                var key = match.Groups[2].Value;
                var nums = match.Groups[1].Value + match.Groups[3].Value;

                var res = new StringBuilder();
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] >= '0' && nums[i] <= '9')
                    {
                        var num = nums[i] - '0';
                        if (num < key.Length)
                        {
                            res.Append(key[num]);
                        }
                        else
                        {
                            res.Append(" ");
                        }

                    }
                }

                Console.WriteLine($"{key} == {res.ToString()}");

                line = Console.ReadLine();
                if (line == "Over!")
                {
                    break;
                }
                m = int.Parse(Console.ReadLine());
            }
        }
    }
}

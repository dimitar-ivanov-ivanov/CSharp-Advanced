namespace BitCarousel
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var n = int.Parse(Console.ReadLine());
            var shifts = int.Parse(Console.ReadLine());
            var bit = Convert.ToString(n, 2).ToCharArray();

            for (int j = 0; j < shifts; j++)
            {
                var line = Console.ReadLine();
                if (line == "right")
                {
                    var lastNum = bit[bit.Length - 1];
                    for (int i = bit.Length - 1; i >= 1; i--)
                    {
                        bit[i] = bit[i - 1];
                    }
                    bit[0] = lastNum;
                }
                else if (line == "left")
                {
                    var firstNum = bit[0];
                    for (int i = 0; i < bit.Length - 1; i++)
                    {
                        bit[i] = bit[i + 1];
                    }
                    bit[bit.Length - 1] = firstNum;
                }
            }

            Console.WriteLine(Convert.ToInt32(new string(bit), 2));
        }
    }
}

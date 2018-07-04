namespace SoftuniNumerals
{
    using System;
    using System.Numerics;
    using System.Text;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var numerals = new string[5];
            numerals[4] = "cdc";
            numerals[3] = "cc";
            numerals[2] = "bcc";
            numerals[1] = "aba";
            numerals[0] = "aa";

            var builder = new StringBuilder();
            var line = Console.ReadLine();

            while (line.Length > 0)
            {
                var changed = false;

                for (int j = numerals.Length - 1; j >= 0; j--)
                {
                    if (line.Length >= numerals[j].Length)
                    {
                        if (line.Substring(0, numerals[j].Length) == numerals[j])
                        {
                            changed = true;
                            line = line.Substring(numerals[j].Length);
                            builder.Append(j.ToString());
                        }
                    }
                }

                if (!changed)
                {
                    break;
                }
            }

            Console.WriteLine(ConvertToDecimal(builder.ToString()));
        }

        private static BigInteger ConvertToDecimal(string base5Num)
        {
            BigInteger sum = 0;

            for (int i = 0; i < base5Num.Length; i++)
            {
                sum += int.Parse(base5Num[i].ToString()) *
                    BigInteger.Pow(5, base5Num.Length - i - 1);
            }

            return sum;
        }
    }
}

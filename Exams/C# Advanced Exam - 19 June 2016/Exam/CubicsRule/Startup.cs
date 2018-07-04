namespace CubicsRule
{
    using System;
    using System.Linq;
    using System.Numerics;

    public class Startup
    {
        public static void Main()
        {
            byte size = byte.Parse(Console.ReadLine());

            var input = Console.ReadLine();

            var sum = new BigInteger();
            var freeDimensions = BigInteger.Pow(size, 3);

            while (input != "Analyze")
            {
                //dimentions - 3 and 1 value that we will use to mark the array with

                var args = input.Split(' ').Select(int.Parse).ToArray();

                var firstDim = args[0];
                var secondDim = args[1];
                var thirdDim = args[2];

                var value = args[3];

                if (firstDim < size && firstDim >= 0 &&
                    secondDim < size && secondDim >= 0 &&
                    thirdDim < size && thirdDim >= 0)
                {
                    sum += value;

                    if (value > 0)
                    {
                        freeDimensions--;
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(sum);
            Console.WriteLine(freeDimensions);
        }
    }
}
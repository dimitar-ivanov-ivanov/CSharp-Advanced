namespace MathPotato
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var kidsArr = Console.ReadLine()
                      .Trim()
                      .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int numberOfTosses = int.Parse(Console.ReadLine());
            Console.WriteLine(Execute(kidsArr, numberOfTosses));

        }

        private static string Execute(string[] kidsArr, int numberOfTosses)
        {
            var res = new StringBuilder();
            Queue<string> kidsPlaying = new Queue<string>(kidsArr);
            var cycle = 1;
            while (kidsPlaying.Count > 1)
            {
                for (int i = 1; i < numberOfTosses; i++)
                {
                    kidsPlaying.Enqueue(kidsPlaying.Dequeue());
                }

                if (isPrime(cycle))
                {
                    res.AppendLine($"Prime {kidsPlaying.Peek()}");
                }
                else
                {
                    res.AppendLine($"Removed {kidsPlaying.Dequeue()}");
                }

                cycle++;
            }

            res.AppendLine($"Last is {kidsPlaying.Peek()}");
            return res.ToString().Trim();
        }

        private static bool isPrime(int number)
        {
            if (number == 1) return false;
            if (number == 2) return true;

            for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
            {
                if (number % divisor == 0)
                    return false;
            }

            return true;
        }
    }
}
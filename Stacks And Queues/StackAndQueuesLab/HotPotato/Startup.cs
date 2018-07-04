namespace HotPotato
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
            while (kidsPlaying.Count > 1)
            {
                for (int i = 1; i < numberOfTosses; i++)
                {
                    kidsPlaying.Enqueue(kidsPlaying.Dequeue());
                }

                res.AppendLine($"Removed {kidsPlaying.Dequeue()}");
            }

            res.AppendLine($"Last is {kidsPlaying.Peek()}");
            return res.ToString().Trim();
        }
    }
}
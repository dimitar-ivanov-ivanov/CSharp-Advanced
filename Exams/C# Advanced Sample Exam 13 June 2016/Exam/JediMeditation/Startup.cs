namespace JediMeditation
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var masters = new Queue<string>();
            var knights = new Queue<string>();
            var padawans = new Queue<string>();
            var toshkoSlav = new Queue<string>();
            var yodaIsPresent = false;
            var args = new string[] { };

            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < args.Length; j++)
                {
                    switch (args[j][0])
                    {
                        case 'm':
                            masters.Enqueue(args[j]);
                            break;
                        case 'k':
                            knights.Enqueue(args[j]);
                            break;
                        case 'p':
                            padawans.Enqueue(args[j]);
                            break;
                        case 't':
                        case 's':
                            toshkoSlav.Enqueue(args[j]);
                            break;
                        case 'y':
                            yodaIsPresent = true;
                            break;
                        default:
                            break;
                    }
                }
            }

            if (!yodaIsPresent)
            {
                Console.Write(string.Join(" ", toshkoSlav) + " ");
            }

            Console.Write(string.Join(" ", masters) + " ");
            Console.Write(string.Join(" ", knights) + " ");

            if (yodaIsPresent)
            {
                Console.Write(string.Join(" ", toshkoSlav) + " ");
            }
            Console.WriteLine(string.Join(" ", padawans) + " ");
        }
    }
}

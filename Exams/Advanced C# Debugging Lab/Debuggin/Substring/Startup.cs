namespace Substring
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
            var line = Console.ReadLine();
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < line.Length; i++)
            {
                var sub = "";

                if (line[i] == 'p')
                {
                    if (i + n >= line.Length)
                    {
                        sub = line.Substring(i, line.Length - i);
                    }
                    else
                    {
                        sub = line.Substring(i, n);
                    }
                }
            }
        }
    }
}

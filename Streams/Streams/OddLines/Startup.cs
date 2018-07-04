namespace OddLines
{
    using System;
    using System.IO;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var counter = 0;
            using (var reader = new StreamReader
                (@"D:\Vsichki  Startupi\Softuni\C# Advanced 2\Streams\files\text.txt"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    if (counter % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }
                    counter++;
                    line = reader.ReadLine();
                }
            }
        }
    }
}
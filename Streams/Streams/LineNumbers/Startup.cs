namespace LineNumbers
{
    using System.IO;

    public class Startup
    {
        public static void Main(string[] args)
        {
            using (var reader = new StreamReader
    (@"D:\Vsichki  Startupi\Softuni\C# Advanced 2\Streams\files\text.txt"))
            {
                using (var writer = new StreamWriter
    (@"D:\Vsichki  Startupi\Softuni\C# Advanced 2\Streams\files\textWithLines.txt"))
                {
                    var counter = 1;
                    var line = reader.ReadLine();

                    while (line != null)
                    {
                        writer.WriteLine($"Line {counter++}: {line}");
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
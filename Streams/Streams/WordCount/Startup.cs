namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var wordsQuantity = new Dictionary<string, int>();

            using (var wordsReader = new StreamReader
                  (@"D:\Vsichki  Startupi\Softuni\C# Advanced 2\Streams\files\words.txt"))
            {
                var word = wordsReader.ReadLine();
                while (word != null)
                {
                    word = word.ToLower();
                    if (!wordsQuantity.ContainsKey(word))
                    {
                        wordsQuantity.Add(word, 0);
                    }
                    word = wordsReader.ReadLine();
                }
            }

            using (var textReader = new StreamReader
                   (@"D:\Vsichki  Startupi\Softuni\C# Advanced 2\Streams\files\text.txt"))
            {
                var line = textReader.ReadLine();

                while (line != null)
                {
                    var currentWords = line.ToLower()
                     .Split(" .,?!:;-[]{}()".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                     .Select(x => x.ToLower())
                     .ToArray();

                    foreach (var word in currentWords)
                    {
                        if (wordsQuantity.ContainsKey(word))
                        {
                            wordsQuantity[word]++;
                        }
                    }

                    line = textReader.ReadLine();
                }
            }

            wordsQuantity = wordsQuantity.OrderByDescending(x => x.Value)
                    .ToDictionary(x => x.Key, x => x.Value);

            using (var writer = new StreamWriter
(@"D:\Vsichki  Startupi\Softuni\C# Advanced 2\Streams\files\result.txt"))
            {
                foreach (var word in wordsQuantity)
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
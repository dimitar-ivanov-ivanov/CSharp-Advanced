namespace SlicingFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class Startup
    {
        private static List<string> filterParts = new List<string>();

        private static void Main(string[] args)
        {
            int partsCount = int.Parse(Console.ReadLine().Replace("parts= ", ""));
            SliceFile(partsCount);
            AssembleFile();
        }

        private static void SliceFile(int partsCount)
        {
            var buffer = new byte[4096];
            using (var sourceFile = new FileStream(@"D:\Vsichki  Startupi\Softuni\C# Advanced 2\Streams\files\sliceMe.mp4", FileMode.Open))
            {
                var partSize = Math.Ceiling((double)sourceFile.Length / partsCount);
                for (int i = 0; i < partsCount; i++)
                {
                    var filePartName = $@"D:\Vsichki  Startupi\Softuni\C# Advanced 2\Streams\files\Part-{i}.mp4";
                    filterParts.Add(filePartName);

                    using (var destinationFile = new FileStream(filePartName, FileMode.Create))
                    {
                        int totalBytes = 0;
                        while (totalBytes < partSize)
                        {
                            int readBytes = sourceFile.Read(buffer, 0, buffer.Length);
                            if (readBytes == 0) break;

                            destinationFile.Write(buffer, 0, readBytes);
                            totalBytes += readBytes;
                        }
                    }
                }
            }
        }

        private static void AssembleFile()
        {
            var buffer = new byte[4096];
            using (var assembledImage = new FileStream(@"D:\Vsichki  Startupi\Softuni\C# Advanced 2\Streams\files\assembled.mp4", FileMode.Create))
            {
                for (int i = 0; i < filterParts.Count; i++)
                {
                    using (var reader = new FileStream(filterParts[i], FileMode.Open))
                    {
                        while (true)
                        {
                            int readBytes = reader.Read(buffer, 0, buffer.Length);
                            if (readBytes == 0) break;

                            assembledImage.Write(buffer, 0, readBytes);
                        }
                    }
                }
            }
        }
    }
}

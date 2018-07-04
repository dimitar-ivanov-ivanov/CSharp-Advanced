namespace ZippingSlicedFiles
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;

    public class Startup
    {
        private static List<string> filterParts = new List<string>();

        public static void Main(string[] args)
        {
            int partsCount = int.Parse(Console.ReadLine().Replace("parts= ", ""));
            SliceFile(partsCount);
            AssembleFile();
        }

        private static void AssembleFile()
        {
            var buffer = new byte[4096];
            using (var assembled = new FileStream(@"D:\Vsichki  Startupi\Softuni\C# Advanced 2\Streams\files\sliceMe.mp4", FileMode.Create))
            {
                for (int i = 0; i < filterParts.Count; i++)
                {
                    using (var partsReader = new FileStream(filterParts[i], FileMode.Open))
                    {
                        using (var compressedFile = new GZipStream(partsReader, CompressionMode.Decompress, false))
                        {
                            while (true)
                            {
                                var readBytes = compressedFile.Read(buffer, 0, buffer.Length);
                                if (readBytes == 0) break;
                                assembled.Write(buffer, 0, readBytes);
                            }
                        }
                    }
                }
            }
        }

        private static void SliceFile(int partsCount)
        {
            var buffer = new byte[4096];
            using (var source = new FileStream(@"D:\Vsichki  Startupi\Softuni\C# Advanced 2\Streams\files\sliceMe.mp4",
                FileMode.Open))
            {
                for (int i = 0; i < partsCount; i++)
                {
                    var partSize = (long)Math.Ceiling((double)source.Length / partsCount);
                    var filePartName = $@"D:\Vsichki  Startupi\Softuni\C# Advanced 2\Streams\files\Part-{i}.gz";
                    filterParts.Add(filePartName);

                    using (var destinationFile = new FileStream(filePartName, FileMode.Create))
                    {
                        using (var compressedFile = new GZipStream(destinationFile, CompressionMode.Compress))
                        {
                            var totalBytes = 0;
                            while (totalBytes < partSize)
                            {
                                var readBytes = source.Read(buffer, 0, buffer.Length);
                                if (readBytes == 0) break;

                                compressedFile.Write(buffer, 0, readBytes);
                                totalBytes += readBytes;
                            }
                        }
                    }
                }
            }
        }
    }
}

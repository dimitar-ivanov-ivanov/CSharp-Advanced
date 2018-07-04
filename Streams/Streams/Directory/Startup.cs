namespace Directory
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var sourcePath = @"D:\Vsichki  Startupi\Softuni\C# Advanced 2\Streams\files";
            var destinationPath = @"D:\Vsichki  Startupi\Softuni\C# Advanced 2\Streams\files\report.txt";
            var filesInDirectory = System.IO.Directory.EnumerateFiles(sourcePath, "*.*", SearchOption.TopDirectoryOnly);

            var fileDict = new Dictionary<string, Dictionary<string, long>>();

            foreach (var file in filesInDirectory)
            {
                var fileInfo = new FileInfo(file);
                var extension = fileInfo.Extension;
                var name = fileInfo.Name;
                var length = fileInfo.Length;

                if (!fileDict.ContainsKey(extension))
                {
                    fileDict.Add(extension, new Dictionary<string, long>());
                }

                if (!fileDict[extension].ContainsKey(name))
                {
                    fileDict[extension].Add(name, 0);
                }

                fileDict[extension][name] += length;
            }

            fileDict = fileDict.OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            using (var report = new StreamWriter(destinationPath))
            {
                foreach (var extension in fileDict)
                {
                    var allFiles = extension.Value.OrderBy(x => x.Value)
                        .ToDictionary(x => x.Key, x => x.Value);

                    report.WriteLine(extension.Key);
                    foreach (var file in allFiles)
                    {
                        report.WriteLine($"--{file.Key} - {(double)file.Value / 1024:f3} kb");
                    }
                }
            }
        }
    }
}
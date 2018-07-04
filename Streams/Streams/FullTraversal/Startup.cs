namespace FullTraversal
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            string sourcePath = @"D:\Vsichki  Startupi\Softuni\C# Advanced 2\Streams";
            string destinationPath = @"D:\Vsichki  Startupi\Softuni\C# Advanced 2\Streams\files";
            var filesDict = new Dictionary<string, Dictionary<string, long>>();

            SearchDirectory(sourcePath, destinationPath, filesDict);
        }

        private static void SearchDirectory(string sourcePath, string destinationPath, Dictionary<string, Dictionary<string, long>> filesDict)
        {
            var filesInDirectory = System.IO.Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories);
            foreach (var file in filesInDirectory)
            {
                var fileInfo = new FileInfo(file);
                var extension = fileInfo.Extension;
                var name = fileInfo.Name;
                var length = fileInfo.Length;

                if (!filesDict.ContainsKey(extension))
                {
                    filesDict[extension] = new Dictionary<string, long>();
                }
                if (!filesDict[extension].ContainsKey(name))
                {
                    filesDict[extension][name] = length;
                }
            }

            filesDict = filesDict
                      .OrderByDescending(x => x.Value.Count)  // number of files
                      .ThenBy(x => x.Key)
                      .ToDictionary(x => x.Key, x => x.Value);

            using (var report = new StreamWriter($"{destinationPath}/reportFullSearch.txt"))
            {
                foreach (var kvp in filesDict)
                {
                    var extension = kvp.Key;
                    var files = filesDict[extension]
                        .OrderByDescending(x => x.Value);
                    report.WriteLine(extension);
                    foreach (var file in files)
                    {
                        report.WriteLine($"--{file.Key} - {(double)file.Value / 1024:f3} kb");
                    }
                }
            }
        }
    }
}
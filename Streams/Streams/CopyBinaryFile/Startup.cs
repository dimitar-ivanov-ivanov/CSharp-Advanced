namespace CopyBinaryFile
{
    using System.IO;

    public class Startup
    {
        public static void Main(string[] args)
        {
            using (var source = new FileStream(@"D:\Vsichki  Startupi\Softuni\C# Advanced 2\Streams\files\copyMe.png", FileMode.Open))
            {
                using (var destination =
                  new FileStream(@"D:\Vsichki  Startupi\Softuni\C# Advanced 2\Streams\files\imageCopy.jpg", FileMode.Create))

                {
                    var bytes = new byte[4096];
                    while (true)
                    {
                        var readBytes = source.Read(bytes, 0, bytes.Length);
                        if (readBytes == 0)
                        {
                            break;
                        }
                        destination.Write(bytes, 0, bytes.Length);
                    }
                }
            }
        }
    }
}
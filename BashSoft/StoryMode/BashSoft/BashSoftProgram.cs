namespace BashSoft
{
    using BashSoft.IO;

    public class BashSoftProgram
    {
        public static void Main(string[] args)
        {
            //IOManager.TraverseDirectory(@"D:\Vsichki  Programi\Softuni\C# Advanced 2\BashSoft\StoryMode\BashSoft");

            // StudentsRepository.InitializeData();
            // StudentsRepository.GetAllStudentsFromCourse("Unity");
            //StudentsRepository.GetStudentsScoresFromCourse("Unity", "Ivan");

            //Tester.CompareContent
            //    (@"D:\Vsichki  Programi\Softuni\C# Advanced 2\BashSoft\StoryMode\BashSoft\Files\test2.txt",
            //     @"D:\Vsichki  Programi\Softuni\C# Advanced 2\BashSoft\StoryMode\BashSoft\Files\test3.txt");

            //IOManager.CreateDirectoryInCurrentFolder("pesho");
            //IOManager.TraverseDirectory(2);

            //IOManager.ChangeCurrentDirectoryAbsolute(@"C:\Windows");
            //IOManager.TraverseDirectory(1);
            //IOManager.TraverseDirectory(20);

            //Tester.CompareContent(@"D:\Vsichki  Programi\Softuni\C# Advanced 2\BashSoft\StoryMode\BashSoft\Files\actual.txt",
            //      @"D:\Vsichki  Programi\Softuni\C# Advanced 2\BashSoft\StoryMode\BashSoft\Files\expected.txt");

            //IOManager.CreateDirectoryInCurrentFolder("*2");

            for (int i = 0; i < 2; i++)
            {
                IOManager.ChangeCurrentDirectoryRelative("..");
            }

            InputReader.StartReadingCommands();
        }
    }
}

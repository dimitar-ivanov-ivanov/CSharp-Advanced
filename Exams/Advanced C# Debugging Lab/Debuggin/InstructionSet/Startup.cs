namespace InstructionSet
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
            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            while (args[0] != "END")
            {
                var first = long.Parse(args[1]);

                switch (args[0])
                {
                    case "INC":
                        first++;
                        Console.WriteLine(first);
                        break;
                    case "DEC":
                        first--;
                        Console.WriteLine(first);
                        break;
                    case "ADD":
                        var second = long.Parse(args[2]);
                        Console.WriteLine(second + first);
                        break;
                    case "MLA":
                        second = long.Parse(args[2]);
                        Console.WriteLine(second * first);
                        break;
                    default:
                        break;
                }

                args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}

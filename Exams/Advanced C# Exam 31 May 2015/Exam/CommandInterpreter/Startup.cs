namespace CommandInterpreter
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var arr = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            while (args[0] != "end")
            {
                switch (args[0])
                {
                    case "reverse":
                        var start = int.Parse(args[2]);
                        var count = int.Parse(args[4]);
                        Reverse(arr, start, count);
                        break;
                    case "sort":
                        start = int.Parse(args[2]);
                        count = int.Parse(args[4]);
                        Sort(arr, start, count);
                        break;
                    case "rollLeft":
                        count = int.Parse(args[1]);
                        RollLeft(arr, count);
                        break;
                    case "rollRight":
                        count = int.Parse(args[1]);
                        RollRight(arr, count);
                        break;
                    default:
                        break;
                }
                args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine($"[{string.Join(", ", arr)}]");
        }

        private static void RollRight(string[] arr, int count)
        {
            if (count < 0)
            {
                Console.WriteLine("Invalid input parameters.");
                return;
            }

            count %= arr.Length;
            for (int j = 0; j < count; j++)
            {
                var last = arr[arr.Length - 1];
                for (int i = arr.Length - 1; i > 0; i--)
                {
                    arr[i] = arr[i - 1];
                }

                arr[0] = last;
            }
        }

        private static void Reverse(string[] arr, int start, int count)
        {
            if (start < 0 || start > arr.Length || count < 0 ||
               count > arr.Length || start + count < 0 ||
               start + count > arr.Length)
            {
                Console.WriteLine("Invalid input parameters.");
                return;
            }

            var reversed = arr.Skip(start)
                .Take(count)
                .Reverse().ToArray();

            for (int i = start, j = 0; i < start + count && i < arr.Length; i++, j++)
            {
                arr[i] = reversed[j];
            }
        }

        private static void Sort(string[] arr, int start, int count)
        {
            if (start < 0 || start > arr.Length || count < 0 ||
                           count > arr.Length || start + count < 0 ||
                           start + count > arr.Length)
            {
                Console.WriteLine("Invalid input parameters.");
                return;
            }

            var sorted = arr.Skip(start)
                .Take(count)
                .OrderBy(x => x)
                .ToArray();

            for (int i = start, j = 0; i < start + count && i < arr.Length; i++, j++)
            {
                arr[i] = sorted[j];
            }
        }

        private static void RollLeft(string[] arr, int count)
        {
            if (count < 0)
            {
                Console.WriteLine("Invalid input parameters.");
                return;
            }

            count %= arr.Length;
            for (int j = 0; j < count; j++)
            {
                var first = arr[0];
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    arr[i] = arr[i + 1];
                }
                arr[arr.Length - 1] = first;
            }
        }
    }
}
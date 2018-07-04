namespace ArrayManipulator
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        public static void Execute()
        {
            var arr = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            while (args[0] != "end")
            {
                switch (args[0])
                {
                    case "exchange":
                        Exchange(arr, int.Parse(args[1]));
                        break;
                    case "max":
                    case "min":
                        MaxMin(arr, args[0], args[1]);
                        break;
                    case "first":
                    case "last":
                        FirstLast(arr, int.Parse(args[1]), args[0], args[2]);
                        break;
                    default:
                        break;
                }
                args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine($"[{string.Join(", ", arr)}]");
        }

        private static void Exchange(int[] arr, int index)
        {
            if (index > arr.Length || index < 0)
            {
                Console.WriteLine("Invalid index");
                return;
            }

            var first = arr.Take(index + 1).ToArray();
            var second = arr.Skip(index + 1).ToArray();

            for (int i = 0; i < second.Length; i++)
            {
                arr[i] = second[i];
            }

            for (int i = second.Length, j = 0; j < first.Length; i++, j++)
            {
                arr[i] = first[j];
            }
        }

        private static void MaxMin(int[] arr, string maxMin, string oddEven)
        {
            var remainder = oddEven == "even" ? 0 : 1;
            var filteredNums = arr.Where(x => x % 2 == remainder)
                .ToArray();

            if (filteredNums.Length == 0)
            {
                Console.WriteLine("No matches");
                return;
            }

            Console.WriteLine(maxMin == "max"
              ? Array.LastIndexOf(arr, filteredNums.Max())
              : Array.LastIndexOf(arr, filteredNums.Min()));

        }

        private static void FirstLast(int[] arr, int count, string firstLast, string oddEven)
        {
            var remainder = oddEven == "even" ? 0 : 1;
            if (count > arr.Length || count < 0)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            var nums = arr.Where(x => x % 2 == remainder).ToArray();

            if (firstLast == "first")
            {
                nums = nums.Take(count).ToArray();
            }
            else if (firstLast == "last")
            {
                nums = nums.Reverse().Take(count).Reverse().ToArray();
            }

            Console.WriteLine($"[{string.Join(", ", nums)}]");
        }
    }
}
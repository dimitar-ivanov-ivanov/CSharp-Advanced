namespace ArrangeIntegers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        public static void Execute()
        {
            var args = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            var nums = new List<KeyValuePair<int, string>>();

            for (int i = 0; i < args.Length; i++)
            {
                var builder = new StringBuilder();
                for (int j = 0; j < args[i].Length; j++)
                {
                    switch (args[i][j])
                    {
                        case '0':
                            builder.Append("zero-");
                            break;
                        case '1':
                            builder.Append("one-");
                            break;
                        case '2':
                            builder.Append("two-");
                            break;
                        case '3':
                            builder.Append("three-");
                            break;
                        case '4':
                            builder.Append("four-");
                            break;
                        case '5':
                            builder.Append("five-");
                            break;
                        case '6':
                            builder.Append("six-");
                            break;
                        case '7':
                            builder.Append("seven-");
                            break;
                        case '8':
                            builder.Append("eight-");
                            break;
                        case '9':
                            builder.Append("nine-");
                            break;
                        default:
                            break;
                    }
                }

                if (builder.Length > 0)
                {
                    builder = builder.Remove(builder.Length - 1, 1);
                }

                nums.Add(new KeyValuePair<int, string>(int.Parse(args[i]), builder.ToString()));
            }

            nums.Sort(new ArrayIntegerComparer());
            Console.WriteLine(string.Join(", ", nums.Select(x => x.Key)));
        }
    }

    public class ArrayIntegerComparer : IComparer<KeyValuePair<int, string>>
    {
        public int Compare(KeyValuePair<int, string> x, KeyValuePair<int, string> y)
        {
            if (x.Value.StartsWith(y.Value)
             || y.Value.StartsWith(x.Value))
            {
                return x.Key.CompareTo(y.Key);
            }

            return x.Value.CompareTo(y.Value);
        }
    }
}

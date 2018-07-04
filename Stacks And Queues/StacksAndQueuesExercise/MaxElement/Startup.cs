namespace MaxElement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            Console.WriteLine(Execute(n));
        }

        private static string Execute(int n)
        {
            var res = new StringBuilder();
            var stack = new Stack<int>();
            long max = -1;

            for (int i = 0; i < n; i++)
            {
                var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                switch (args[0])
                {
                    case "1":
                        var toPush = int.Parse(args[1]);
                        if (toPush > max)
                        {
                            max = toPush;
                        }

                        stack.Push(toPush);
                        break;
                    case "2":
                        if (stack.Any())
                        {
                            var toPop = stack.Peek();
                            if (max == toPop)
                            {
                                max = -1;
                            }
                            stack.Pop();
                        }
                        break;
                    case "3":
                        if (stack.Any())
                        {
                            if (max == -1)
                            {
                                max = stack.Max();
                            }

                            res.AppendLine(max.ToString());
                        }
                        break;
                    default:
                        break;
                }
            }

            return res.ToString();
        }
    }
}
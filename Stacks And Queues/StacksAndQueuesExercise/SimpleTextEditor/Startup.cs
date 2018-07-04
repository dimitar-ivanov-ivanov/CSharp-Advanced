namespace SimpleTextEditor
{
    using System;
    using System.Collections.Generic;
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
            var builder = new StringBuilder();
            var texts = new Stack<string>();
            texts.Push(string.Empty);
            string[] args;

            for (int i = 0; i < n; i++)
            {
                args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var last = texts.Peek().ToString();

                switch (args[0])
                {
                    case "1":
                        texts.Push(last + args[1]);
                        break;
                    case "2":
                        var num = int.Parse(args[1]);
                        if (num <= last.Length)
                        {
                            last = last.Remove(last.Length - num, num);
                            texts.Push(last);
                        }
                        break;
                    case "3":
                        num = int.Parse(args[1]);
                        if (num <= last.Length)
                        {
                            builder.AppendLine(last[num - 1].ToString());
                        }
                        break;
                    case "4":
                        texts.Pop();
                        if (texts.Count == 0)
                        {
                            texts.Push(String.Empty);
                        }
                        break;
                    default:
                        break;
                }
            }

            return builder.ToString();
        }
    }
}

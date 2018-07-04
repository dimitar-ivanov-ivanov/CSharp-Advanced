namespace ExtractEmails
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Execute());
        }

        private static string Execute()
        {
            var args = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            var regex = new Regex(@"^[a-zA-Z][\w.-]+@[a-zA-Z][a-z-A-Z-]+\.[a-z-A-Z.]+$");
            var output = new StringBuilder();
            var len = args.Length;
            if (len > 0)
            {
                var lastChar = args[len - 1][args[len - 1].Length - 1];
                if (lastChar == '.' || lastChar == '?' || lastChar == '!')
                {
                    args[len - 1] = args[len - 1].Remove(args[len - 1].Length - 1, 1);
                }
            }

            for (int i = 0; i < args.Length; i++)
            {
                if (regex.IsMatch(args[i]))
                {
                    if (args[i][args[i].Length - 1] == '.')
                    {
                        args[i].Remove(args[i].Length - 1, 1);
                    }
                    output.AppendLine(args[i]);
                }
            }

            return output.ToString();
        }
    }
}

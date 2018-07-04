namespace BasicMarkUpLanguage
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var regex = new Regex(@"<(\w+)\s+((value)\s*=\s*""(\w+)"")*\s*(content\s*=\s*""(\w+)"")\/>");
            var line = Console.ReadLine();
            var counter = 1;

            while (line != "<stop/>")
            {
                if (!regex.IsMatch(line))
                {
                    line = Console.ReadLine();
                    continue;
                }

                var match = regex.Match(line);
                var command = match.Groups[1].Value;
                var content = match.Groups[6].Value;
                var builder = new StringBuilder();

                switch (command)
                {
                    case "inverse":
                        for (int i = 0; i < content.Length; i++)
                        {
                            if (char.IsUpper(content[i]))
                            {
                                builder.Append(content[i].ToString().ToLower()[0]);
                            }
                            else if (char.IsLower(content[i]))
                            {
                                builder.Append(content[i].ToString().ToUpper()[0]);
                            }
                        }
                        Console.WriteLine($"{counter++}. {builder.ToString()}");
                        break;
                    case "reverse":
                        builder.Append(new string(content.Reverse().ToArray()));
                        Console.WriteLine($"{counter++}. {builder.ToString()}");
                        break;
                    case "repeat":
                        var repeatCounter = int.Parse(match.Groups[4].Value);
                        for (int i = 0; i < repeatCounter; i++)
                        {
                            Console.WriteLine($"{counter++}. {content}");
                        }
                        break;
                    default:
                        break;
                }
                line = Console.ReadLine();
            }
        }
    }
}

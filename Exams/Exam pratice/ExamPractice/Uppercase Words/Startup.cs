namespace Uppercase_Words
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security;
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
            var list = new List<string>();
            var line = Console.ReadLine();

            while (line != "END")
            {
                list.Add(line);
                line = Console.ReadLine();
            }

            for (int i = 0; i < list.Count; i++)
            {
                var args = list[i].Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < args.Length; j++)
                {
                    if (args[j] == args[j].ToUpper())
                    {
                        //int firstXIndex =  Regex.Match(myText,"([0-9]+)(x)([0-9]+)").Groups[2].Index;
                        var ind = Regex.Match(args[j], $"\\b({args[j]})\\b").Groups[1].Index;
                        list[i] = list[i].Remove(ind, args[j].Length);

                        var reverse = new string(args[j].Reverse().ToArray());
                        if (reverse == args[j])
                        {
                            var builder = new StringBuilder();
                            for (int k = 0; k < args[j].Length; k++)
                            {
                                builder.Append(args[j][k]);
                                builder.Append(args[j][k]);
                            }

                            args[j] = builder.ToString();
                        }
                        else
                        {
                            args[j] = reverse;
                        }

                        list[i] = list[i].Insert(ind, args[j]);
                    }
                }

                list[i] = SecurityElement.Escape(list[i]);
            }

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }
    }
}

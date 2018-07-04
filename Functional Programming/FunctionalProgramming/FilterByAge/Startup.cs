namespace FilterByAge
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            string[] args;
            var n = int.Parse(Console.ReadLine());
            var arr = new KeyValuePair<string, int>[n];

            for (int i = 0; i < n; i++)
            {
                args = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                arr[i] = new KeyValuePair<string, int>(args[0], int.Parse(args[1]));
            }

            var condition = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Func<KeyValuePair<string, int>, bool> ageCond = p => condition == "older" ? p.Value >= age : p.Value < age;

            Func<KeyValuePair<string, int>, string> output = p => args.Length == 1 ?
             (args[0] == "name" ? p.Key : p.Value.ToString()) : $"{p.Key} - {p.Value}";

            var res = arr.Where(ageCond)
                .Select(output);

            Console.WriteLine(string.Join("\n", res));
        }
    }
}

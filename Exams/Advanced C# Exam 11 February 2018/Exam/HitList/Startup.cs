namespace HitList
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
            var targetInfoIndex = int.Parse(Console.ReadLine());
            var people = new Dictionary<string, Dictionary<string, string>>();

            var args = Console.ReadLine().Split(new[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);
            while (args[0] != "end transmissions")
            {
                var name = args[0];
                if (!people.ContainsKey(name))
                {
                    people.Add(name, new Dictionary<string, string>());
                }

                for (int j = 1; j < args.Length; j++)
                {
                    var infoArgs = args[j].Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < infoArgs.Length; i += 2)
                    {
                        var key = infoArgs[i];
                        var val = infoArgs[i + 1];

                        if (!people[name].ContainsKey(key))
                        {
                            people[name].Add(key, "");
                        }

                        people[name][key] = val;
                    }
                }

                args = Console.ReadLine().Split(new[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);
            }

            Print(people, targetInfoIndex);
        }

        private static void Print(Dictionary<string, Dictionary<string, string>> people, int targetInfoIndex)
        {
            var personToKill = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1];

            if (people.ContainsKey(personToKill))
            {
                Console.WriteLine($"Info on {personToKill}:");
                var infoOnPerson = people[personToKill]
                    .OrderBy(x => x.Key)
                    .ToDictionary(x => x.Key, x => x.Value);

                var infoTotalLength = 0;

                foreach (var info in infoOnPerson)
                {
                    infoTotalLength += info.Key.Length;
                    infoTotalLength += info.Value.Length;
                    Console.WriteLine($"---{info.Key}: {info.Value}");
                }

                Console.WriteLine($"Info index: {infoTotalLength}");
                if (infoTotalLength >= targetInfoIndex)
                {
                    Console.WriteLine("Proceed");
                }
                else
                {
                    Console.WriteLine($"Need {targetInfoIndex - infoTotalLength} more info.");
                }
            }
        }
    }
}
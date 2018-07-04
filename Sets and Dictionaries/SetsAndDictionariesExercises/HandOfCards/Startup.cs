namespace HandOfCards
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Execute());
        }

        private static string Execute()
        {
            var powers = new Dictionary<string, int>();
            var types = new Dictionary<string, int>();
            var res = new StringBuilder();

            for (int i = 2; i <= 10; i++)
            {
                powers.Add(i.ToString(), i);
            }

            powers.Add("J", 11);
            powers.Add("Q", 12);
            powers.Add("K", 13);
            powers.Add("A", 14);

            types.Add("S", 4);
            types.Add("H", 3);
            types.Add("D", 2);
            types.Add("C", 1);

            var people = new Dictionary<string, HashSet<string>>();
            var args = Console.ReadLine().Split(new[] { ' ', ',', ':' }, StringSplitOptions.RemoveEmptyEntries);

            while (args[0] != "JOKER")
            {
                var name = args[0];
                if (!people.ContainsKey(name))
                {
                    people.Add(name, new HashSet<string>());
                }

                for (int i = 1; i < args.Length; i++)
                {
                    people[name].Add(args[i]);
                }
                args = Console.ReadLine().Split(new[] { ' ', ',', ':' }, StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var person in people)
            {
                var name = person.Key;
                var score = 0;
                foreach (var card in person.Value)
                {
                    var power = card.Substring(0, card.Length - 1);
                    var type = card[card.Length - 1].ToString();
                    score += types[type] * powers[power];
                }

                res.AppendLine($"{name}: {score}");
            }

            return res.ToString();
        }
    }
}
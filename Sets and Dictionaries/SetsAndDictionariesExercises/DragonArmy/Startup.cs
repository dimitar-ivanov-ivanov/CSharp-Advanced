namespace DragonArmy
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
            var typeDragons = new Dictionary<string, Dictionary<string, int[]>>();
            var typeStats = new Dictionary<string, decimal[]>();
            var builder = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var type = args[0];
                var dragon = args[1];
                var damage = int.Parse(args[2] == "null" ? "45" : args[2]);
                var health = int.Parse(args[3] == "null" ? "250" : args[3]);
                var armor = int.Parse(args[4] == "null" ? "10" : args[4]);

                if (!typeDragons.ContainsKey(type))
                {
                    typeStats.Add(type, new decimal[3]);
                    typeDragons.Add(type, new Dictionary<string, int[]>());
                }

                if (!typeDragons[type].ContainsKey(dragon))
                {
                    typeDragons[type].Add(dragon, new int[] { damage, health, armor });
                }

                typeStats[type][0] += damage;
                typeStats[type][1] += health;
                typeStats[type][2] += armor;
            }

            foreach (var type in typeDragons)
            {
                var avgDamage = typeStats[type.Key][0] / type.Value.Count;
                var avgHealth = typeStats[type.Key][1] / type.Value.Count;
                var avgArmor = typeStats[type.Key][2] / type.Value.Count;

                builder.AppendLine($"{type.Key}::({avgDamage:f2}/{avgHealth:f2}/{avgArmor:f2})");

                var dragons = type.Value.OrderBy(d => d.Key)
                    .ToDictionary(x => x.Key, x => x.Value);

                foreach (var d in dragons)
                {
                    builder.AppendLine($"-{d.Key} -> damage: {d.Value[0]}, health: {d.Value[1]}, armor: {d.Value[2]}");
                }
            }

            return builder.ToString();
        }
    }
}
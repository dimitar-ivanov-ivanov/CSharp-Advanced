namespace CollectResources
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var possibleResources = new HashSet<string>()
                          { "stone","gold","wood","food"};

            var args = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var n = args.Length;
            var quantities = new int[n];

            for (int i = 0; i < n; i++)
            {
                var resourceQuantity = args[i].Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                var resource = resourceQuantity[0];
                var quantity = 1;

                if (resourceQuantity.Length > 1)
                {
                    quantity = int.Parse(resourceQuantity[1]);
                }

                if (!possibleResources.Contains(resource))
                {
                    quantity = 0;
                }
                quantities[i] = quantity;
            }

            var patterns = int.Parse(Console.ReadLine());
            long res = 0;

            for (int j = 0; j < patterns; j++)
            {
                args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var start = int.Parse(args[0]);
                var step = int.Parse(args[1]);
                var visited = new bool[n];
                long path = 0;

                for (int i = start; i < n; i = (i + step) % n)
                {
                    if (visited[i])
                    {
                        break;
                    }

                    visited[i] = true;
                    path += quantities[i];
                }

                res = Math.Max(path, res);
            }

            Console.WriteLine(res);
        }
    }
}

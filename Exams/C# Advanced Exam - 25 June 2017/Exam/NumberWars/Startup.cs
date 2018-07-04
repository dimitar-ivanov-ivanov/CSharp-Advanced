namespace NumberWars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Execute());
        }

        private static string Execute()
        {
            var first = new Queue<string>(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            var second = new Queue<string>(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            var count = 0;

            while (first.Count != 0 && second.Count != 0)
            {
                var topFirst = first.Dequeue();
                var topSecond = second.Dequeue();
                var firstSum = int.Parse(topFirst.Substring(0, topFirst.Length - 1));
                var secondSum = int.Parse(topSecond.Substring(0, topSecond.Length - 1));

                if (firstSum != secondSum)
                {
                    if (firstSum > secondSum)
                    {
                        first.Enqueue(topFirst);
                        first.Enqueue(topSecond);
                    }
                    else
                    {
                        second.Enqueue(topSecond);
                        second.Enqueue(topFirst);
                    }
                }
                else
                {
                    CardsAreEqual(first, second);
                }

                count++;
                if (count == 1000000) break;
            }

            return Print(first, second, count);
        }

        private static string Print(Queue<string> first, Queue<string> second, int count)
        {
            if (first.Count == second.Count)
            {
                return $"Draw after {count} turns";
            }
            else if (first.Count > second.Count)
            {
                return $"First player wins after {count} turns";
            }
            else
            {
                return $"Second player wins after {count} turns";
            }
        }

        private static void CardsAreEqual(Queue<string> first, Queue<string> second)
        {
            var cards = new List<string>();
            while (first.Count > 0 && second.Count > 0)
            {
                var fa = first.Dequeue(); var fb = first.Dequeue();
                var fc = first.Dequeue();
                var sa = second.Dequeue(); var sb = second.Dequeue();
                var sc = second.Dequeue();

                var firstCharSum = 26 - ('z' - fa[fa.Length - 1]) +
                    26 - ('z' - fb[fb.Length - 1]) +
                    26 - ('z' - fc[fc.Length - 1]);
                var secondCharSum = 26 - ('z' - sa[sa.Length - 1]) +
                   26 - ('z' - sb[sb.Length - 1]) +
                   26 - ('z' - sc[sc.Length - 1]);

                if (firstCharSum == secondCharSum)
                {
                    cards.Add(fa);
                    cards.Add(fb);
                    cards.Add(fc);
                    cards.Add(sa);
                    cards.Add(sb);
                    cards.Add(sc);
                }
                else if (firstCharSum > secondCharSum)
                {
                    cards = cards.OrderByDescending(x => x).ToList();
                    for (int i = 0; i < cards.Count; i++)
                    {
                        first.Enqueue(cards[i]);
                    }
                }
                else if (firstCharSum < secondCharSum)
                {
                    cards = cards.OrderByDescending(x => x).ToList();
                    for (int i = 0; i < cards.Count; i++)
                    {
                        second.Enqueue(cards[i]);
                    }
                }
            }

            if (first.Count == 0 && second.Count != 0)
            {
                cards = cards.OrderByDescending(x => x).ToList();
                for (int i = 0; i < cards.Count; i++)
                {
                    second.Enqueue(cards[i]);
                }
            }
            else if (second.Count == 0 && first.Count != 0)
            {
                cards = cards.OrderByDescending(x => x).ToList();
                for (int i = 0; i < cards.Count; i++)
                {
                    first.Enqueue(cards[i]);
                }
            }
        }
    }
}

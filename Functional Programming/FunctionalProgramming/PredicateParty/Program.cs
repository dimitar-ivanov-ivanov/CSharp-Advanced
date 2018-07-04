using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, string, bool> startsWith = (x, y) => x.StartsWith(y);
            Func<string, string, bool> endsWith = (x, y) => x.EndsWith(y);
            Func<string, int, bool> lenght = (x, y) => x.Length == y;

            Action<List<string>, string> remove = (x, y) => x.Remove(y);
            Action<List<string>, string> doubleName = (x, y) => x.Insert(x.IndexOf(y),y);

            var list = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            while (!string.Join("", args).Equals("Party!"))
            {
                if(args[0] == "Double")
                {
                    if(args[1] == "Length")
                    {
                        var len = int.Parse(args[2]);
                       var equalLengthStr = list.Where(x => lenght(x, len));
                    }
                }
                else
                {

                }

                args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}

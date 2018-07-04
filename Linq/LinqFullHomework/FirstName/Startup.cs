namespace FirstName
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Execute());
        }

        private static string Execute()
        {
            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var letters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var res = args.Where(x => letters.Contains(x[0].ToString().ToLower()) ||
                                    letters.Contains(x[0].ToString().ToUpper()))
                                    .OrderBy(x => x)
                                    .FirstOrDefault();
            return res ?? "No match";
        }
    }
}

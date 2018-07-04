namespace MelrahShake
{
    using System;
    using System.Text;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Execute());
        }

        private static string Execute()
        {
            var input = Console.ReadLine();
            var key = Console.ReadLine();
            var builder = new StringBuilder();

            while (key.Length > 0 && input.Length > 0 && input.Length > key.Length)
            {
                var oldLen = input.Length;
                var firstOccurance = input.IndexOf(key);
                var lastOccurance = input.LastIndexOf(key);

                if (firstOccurance == -1)
                {
                    break;
                }

                input = input.Remove(firstOccurance, key.Length);
                if (input.Length < key.Length)
                {
                    break;
                }

                input = input.Remove(lastOccurance - key.Length, key.Length);
                builder.AppendLine("Shaked it.");
                key = key.Remove(key.Length / 2, 1);
            }

            builder.AppendLine("No shake.");
            builder.Append(input);
            return builder.ToString();
        }
    }
}

namespace MatrixPalindromes
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
            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var n = int.Parse(args[0]);
            var m = int.Parse(args[1]);
            var builder = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                var first = (char)('a' + i);
                for (int j = 0; j < m; j++)
                {
                    var middle = (char)('a' + j + i);
                    var str = first + "" + middle + "" + first + " ";
                    builder.Append(str);
                }
                builder.AppendLine();
            }

            return builder.ToString();
        }
    }
}

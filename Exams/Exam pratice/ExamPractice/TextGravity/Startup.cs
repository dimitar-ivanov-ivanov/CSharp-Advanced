namespace TextGravity
{
    using System;
    using System.Security;
    using System.Text;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var m = int.Parse(Console.ReadLine());
            var line = Console.ReadLine();
            var n = line.Length / m;

            if (line.Length % m != 0)
            {
                n++;
            }

            var matrix = new char[n, m];
            for (int i = 0, index = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++, index++)
                {
                    if (index < line.Length)
                    {
                        matrix[i, j] = line[index];
                    }
                    else
                    {
                        matrix[i, j] = ' ';
                    }
                }
            }

            for (int i = n - 2; i >= 0; i--)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] != ' ' && matrix[i + 1, j] == ' ')
                    {
                        for (int k = i + 1; k < n; k++)
                        {
                            if (matrix[k, j] != ' ')
                            {
                                break;
                            }

                            var temp = matrix[k - 1, j];
                            matrix[k - 1, j] = matrix[k, j];
                            matrix[k, j] = temp;
                        }
                    }
                }
            }

            var builder = new StringBuilder("<table>");
            for (int i = 0; i < n; i++)
            {
                builder.Append("<tr>");
                for (int j = 0; j < m; j++)
                {
                    var str = SecurityElement.Escape(matrix[i, j].ToString());
                    builder.Append($"<td>{str}</td>");
                }

                builder.Append("</tr>");
            }
            builder.Append("</table>");

            Console.WriteLine(builder);
        }
    }
}

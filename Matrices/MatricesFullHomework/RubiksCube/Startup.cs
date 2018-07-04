namespace RubiksCube
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
            var originalMatrix = new int[n][];
            var matrix = new int[n][];
            for (int i = 0, sum = 1; i < n; i++)
            {
                matrix[i] = new int[m];
                originalMatrix[i] = new int[m];
                for (int j = 0; j < m; j++, sum++)
                {
                    matrix[i][j] += sum;
                    originalMatrix[i][j] += sum;
                }
            }


            var commands = int.Parse(Console.ReadLine());
            for (int i = 0; i < commands; i++)
            {
                args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var rowCol = int.Parse(args[0]);
                var moves = int.Parse(args[2]);
                var direction = args[1];

                if (direction == "left")
                {
                    matrix[rowCol] = RotateLeft(moves, matrix[rowCol]);
                }
                else if (direction == "right")
                {
                    matrix[rowCol] = RotateRight(moves, matrix[rowCol]);
                }
                else
                {
                    RotateVertically(rowCol, direction, moves, matrix);
                }
                Console.WriteLine();
            }

            return GetDifference(n, m, matrix, originalMatrix);
        }

        private static string GetDifference(int n, int m, int[][] matrix, int[][] originalMatrix)
        {
            var builder = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    var foundNumber = false;
                    for (int k = 0; k < n; k++)
                    {
                        for (int p = 0; p < m; p++)
                        {
                            if (originalMatrix[i][j] == matrix[k][p])
                            {
                                if (i == k && p == j)
                                {
                                    builder.AppendLine("No swap required");
                                }
                                else
                                {
                                    var temp = matrix[i][j];
                                    matrix[i][j] = matrix[k][p];
                                    matrix[k][p] = temp;
                                    builder.AppendLine($"Swap ({i}, {j}) with ({k}, {p})");
                                }

                                foundNumber = true;
                                break;
                            }
                        }
                        if (foundNumber)
                        {
                            break;
                        }
                    }
                }
            }

            return builder.ToString();
        }

        private static int[] RotateLeft(int moves, int[] arr)
        {
            moves %= arr.Length;
            for (int j = 0; j < moves; j++)
            {
                var first = arr[0];
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    arr[i] = arr[i + 1];
                }
                arr[arr.Length - 1] = first;
            }
            return arr;
        }

        private static int[] RotateRight(int moves, int[] arr)
        {
            moves %= arr.Length;
            for (int j = 0; j < moves; j++)
            {
                var last = arr[arr.Length - 1];
                for (int i = arr.Length - 1; i > 0; i--)
                {
                    arr[i] = arr[i - 1];
                }
                arr[0] = last;
            }
            return arr;
        }

        private static void RotateVertically(int col, string direction, int moves, int[][] matrix)
        {
            var arr = new int[matrix.Length];
            for (int i = 0; i < matrix.Length; i++)
            {
                arr[i] = matrix[i][col];
            }

            if (direction == "up")
            {
                arr = RotateLeft(moves, arr);
            }
            else
            {
                arr = RotateRight(moves, arr);
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i][col] = arr[i];
            }
        }
    }
}

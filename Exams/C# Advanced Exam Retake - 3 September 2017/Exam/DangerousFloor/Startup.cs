namespace DangerousFloor
{
    using System;
    using System.Linq;

    public class Startup
    {
        static int n = 8;

        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var matrix = new char[n][];

            for (int i = 0; i < n; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(p => p[0]).ToArray();
            }

            var line = Console.ReadLine();
            while (line != "END")
            {
                MoveFigure(line, matrix);
                line = Console.ReadLine();
            }

        }

        private static void MoveFigure(string line, char[][] matrix)
        {
            var figure = line[0];
            var startRow = line[1] - '0';
            var startCol = line[2] - '0';
            var endRow = line[4] - '0';
            var endCol = line[5] - '0';

            if (!InMatrix(startRow, startCol) || matrix[startRow][startCol] != figure)
            {
                Console.WriteLine("There is no such a piece!");
                return;
            }

            if (!InMatrix(endRow, endCol))
            {
                Console.WriteLine("Move go out of board!");
                return;
            }

            var movedFigure = false;
            switch (figure)
            {
                case 'K':
                    movedFigure = MoveKing(startRow, startCol, endRow, endCol, matrix);
                    break;
                case 'R':
                    movedFigure = MoveRook(startRow, startCol, endRow, endCol, matrix);
                    break;
                case 'B':
                    movedFigure = MoveBishop(startRow, startCol, endRow, endCol, matrix);
                    break;
                case 'Q':
                    movedFigure = MoveQueen(startRow, startCol, endRow, endCol, matrix);
                    break;
                case 'P':
                    movedFigure = MovePawn(startRow, startCol, endRow, endCol, matrix);
                    break;
                default:
                    break;
            }

            if (!movedFigure)
            {
                Console.WriteLine("Invalid move!");
            }
        }

        private static bool MovePawn(int startRow, int startCol, int endRow, int endCol, char[][] matrix)
        {
            if (startRow - 1 == endRow)
            {
                if (startCol - 1 == endCol && InMatrix(startRow - 1, startCol - 1))
                {
                    matrix[endRow][endCol] = 'P';
                    matrix[startRow][startCol] = 'x';
                    return true;
                }
                if (startCol == endCol && InMatrix(startRow - 1, startCol))
                {
                    matrix[endRow][endCol] = 'P';
                    matrix[startRow][startCol] = 'x';
                    return true;
                }
                if (startCol + 1 == endCol && InMatrix(startRow - 1, startCol + 1))
                {
                    matrix[endRow][endCol] = 'P';
                    matrix[startRow][startCol] = 'x';
                    return true;
                }
            }
            return false;
        }

        private static bool MoveRook(int startRow, int startCol, int endRow, int endCol, char[][] matrix)
        {
            if ((startRow != endRow && startCol != endCol) ||
               matrix[endRow][endCol] != 'x')
            {
                return false;
            }

            matrix[endRow][endCol] = 'R';
            matrix[startRow][startCol] = 'x';
            return true;
        }

        private static bool MoveQueen(int startRow, int startCol, int endRow, int endCol, char[][] matrix)
        {
            if (matrix[endRow][endCol] != 'x')
            {
                return false;
            }

            for (int i = 1; i <= n; i++)
            {
                if (startRow - i == endRow && startCol == endCol &&
                    InMatrix(startRow - i, startCol))
                {
                    matrix[endRow][endCol] = 'Q';
                    matrix[startRow][startCol] = 'x';
                    return true;
                }

                if (startRow + i == endRow && startCol == endCol &&
                   InMatrix(startRow + i, startCol))
                {
                    matrix[endRow][endCol] = 'Q';
                    matrix[startRow][startCol] = 'x';
                    return true;
                }

                if (startRow == endRow && startCol - i == endCol &&
                   InMatrix(startRow, startCol - i))
                {
                    matrix[endRow][endCol] = 'Q';
                    matrix[startRow][startCol] = 'x';
                    return true;
                }

                if (startRow == endRow && startCol + i == endCol &&
                    InMatrix(startRow, startCol + i))
                {
                    matrix[endRow][endCol] = 'Q';
                    matrix[startRow][startCol] = 'x';
                    return true;
                }

                if (startRow - i == endRow && startCol - i == endCol &&
                    InMatrix(startRow - i, startCol - i))
                {
                    matrix[endRow][endCol] = 'Q';
                    matrix[startRow][startCol] = 'x';
                    return true;
                }

                if (startRow - i == endRow && startCol + i == endCol &&
                   InMatrix(startRow - i, startCol + i))
                {
                    matrix[endRow][endCol] = 'Q';
                    matrix[startRow][startCol] = 'x';
                    return true;
                }

                if (startRow + i == endRow && startCol - i == endCol &&
                   InMatrix(startRow + i, startCol - i))
                {
                    matrix[endRow][endCol] = 'Q';
                    matrix[startRow][startCol] = 'x';
                    return true;
                }

                if (startRow + i == endRow && startCol + i == endCol &&
                   InMatrix(startRow + i, startCol + i))
                {
                    matrix[endRow][endCol] = 'Q';
                    matrix[startRow][startCol] = 'x';
                    return true;
                }
            }

            return false;
        }

        private static bool MoveBishop(int startRow, int startCol, int endRow, int endCol, char[][] matrix)
        {
            if (matrix[endRow][endCol] != 'x')
            {
                return false;
            }

            for (int i = 1; i <= n; i++)
            {
                if (startRow - i == endRow && startCol - i == endCol &&
                    InMatrix(startRow - i, startCol - i))
                {
                    matrix[endRow][endCol] = 'B';
                    matrix[startRow][startCol] = 'x';
                    return true;
                }

                if (startRow - i == endRow && startCol + i == endCol &&
                   InMatrix(startRow - i, startCol + i))
                {
                    matrix[endRow][endCol] = 'B';
                    matrix[startRow][startCol] = 'x';
                    return true;
                }

                if (startRow + i == endRow && startCol - i == endCol &&
                   InMatrix(startRow + i, startCol - i))
                {
                    matrix[endRow][endCol] = 'B';
                    matrix[startRow][startCol] = 'x';
                    return true;
                }

                if (startRow + i == endRow && startCol + i == endCol &&
                   InMatrix(startRow + i, startCol + i))
                {
                    matrix[endRow][endCol] = 'B';
                    matrix[startRow][startCol] = 'x';
                    return true;
                }
            }

            return false;
        }

        private static bool MoveKing(int startRow, int startCol, int endRow, int endCol, char[][] matrix)
        {
            if (InMatrix(startRow - 1, startCol) && endRow == startRow - 1 && endCol == startCol)
            {
                matrix[startRow][startCol] = 'x';
                matrix[startRow - 1][startCol] = 'K';
                return true;
            }
            if (InMatrix(startRow + 1, startCol) && endRow == startRow + 1 && endCol == startCol)
            {
                matrix[startRow][startCol] = 'x';
                matrix[startRow + 1][startCol] = 'K';
                return true;
            }

            if (InMatrix(startRow - 1, startCol - 1) && endRow == startRow - 1 && endCol == startCol - 1)
            {
                matrix[startRow][startCol] = 'x';
                matrix[startRow - 1][startCol - 1] = 'K';
                return true;
            }
            if (InMatrix(startRow - 1, startCol + 1) && endRow == startRow - 1 && endCol == startCol + 1)
            {
                matrix[startRow][startCol] = 'x';
                matrix[startRow - 1][startCol + 1] = 'K';
                return true;
            }

            if (InMatrix(startRow, startCol - 1) && endRow == startRow && endCol == startCol - 1)
            {
                matrix[startRow][startCol] = 'x';
                matrix[startRow][startCol - 1] = 'K';
                return true;
            }
            if (InMatrix(startRow, startCol + 1) && endRow == startRow && endCol == startCol + 1)
            {
                matrix[startRow][startCol] = 'x';
                matrix[startRow][startCol + 1] = 'K';
                return true;
            }

            if (InMatrix(startRow + 1, startCol - 1) && endRow == startRow + 1 && endCol == startCol - 1)
            {
                matrix[startRow][startCol] = 'x';
                matrix[startRow + 1][startCol - 1] = 'K';
                return true;
            }
            if (InMatrix(startRow + 1, startCol + 1) && endRow == startRow + 1 && endCol == startCol + 1)
            {
                matrix[startRow][startCol] = 'x';
                matrix[startRow + 1][startCol + 1] = 'K';
                return true;
            }

            return false;
        }

        private static bool InMatrix(int row, int col)
        {
            return row >= 0 && row < n && col >= 0 && col < n;
        }
    }
}
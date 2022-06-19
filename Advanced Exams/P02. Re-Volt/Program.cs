using System;

namespace P02._Re_Volt
{
    internal class Program
    {
        private static char[,] matrix;
        private static bool IsWon = false;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            matrix = new char[n, n];
            int commandsCount = int.Parse(Console.ReadLine());

            for (int r = 0; r < n; r++)
            {
                string input = Console.ReadLine();
                for (int c = 0; c < n; c++)
                {
                    matrix[r, c] = input[c];
                }
            }
            for (int i = 0; i < commandsCount; i++)
            {
                char start = 'f';
                int[] coordinatesOff = FindCoordinates(start);
                int rowf = coordinatesOff[0];
                int colf = coordinatesOff[1];
                string command = Console.ReadLine();

                if (command == "up")
                {
                    MoveUp(rowf, colf);
                }
                else if (command == "down")
                {
                    MoveDown(rowf, colf);
                }
                else if (command == "left")
                {
                    MoveLeft(rowf, colf);
                }
                else if (command == "right")
                {
                    MoveRight(rowf, colf);  
                }
                if (IsWon)
                {
                    break;
                }
            }
            if (IsWon)
            {
                Console.WriteLine("Player won!");

            }
            else
            {
                Console.WriteLine("Player lost!");
            }
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    Console.Write(matrix[r,c]);
                }
                Console.WriteLine();
            }
        }
        static void MoveUp(int row, int col)
        {
            matrix[row, col] = '-';
            row--;
            if (row < 0)
            {
                row = matrix.GetLength(0) - 1;
            }
            if (matrix[row, col] == 'F')
            {
                matrix[row, col] = 'f';
                IsWon = true;
                return;
            }
            else if (matrix[row, col] == 'B')
            {
                row--;
                if (row < 0)
                {
                    row = matrix.GetLength(0) - 1;
                }
                matrix[row, col] = 'f';
            }
            else if (matrix[row, col] == 'T')
            {
                row++;
                if (row>matrix.GetLength(0)-1)
                {
                    row = 0;
                }
                matrix[row, col] = 'f';
            }
            else
            {
                matrix[row,col] = 'f';  
            }
        }
        static void MoveDown(int row,int col)
        {
            matrix[row, col] = '-';
            row++;
            if (row > matrix.GetLength(0) - 1)
            {
                row = 0;
            }
            if (matrix[row, col] == 'F')
            {
                matrix[row, col] = 'f';
                IsWon = true;
                return;
            }
            else if (matrix[row, col] == 'B')
            {
                row++;
                if (row > matrix.GetLength(0) - 1)
                {
                    row = 0;
                }
                matrix[row, col] = 'f';
            }
            else if (matrix[row, col] == 'T')
            {
                row--;
                if (row<0)
                {
                    row = matrix.GetLength(0) - 1;
                }
                matrix[row, col] = 'f';
            }
            else
            {
                matrix[row,col]= 'f';   
            }
        }
        static void MoveRight(int row,int col)
        {
            matrix[row, col] = '-';
            col++;
            if (col > matrix.GetLength(0) - 1)
            {
                col = 0;
            }
            if (matrix[row, col] == 'F')
            {
                matrix[row, col] = 'f';
                IsWon = true;
                return;
            }
            else if (matrix[row, col] == 'B')
            {
                col++;
                if (col > matrix.GetLength(0) - 1)
                {
                    col = 0;
                }
                matrix[row, col] = 'f';
            }
            else if (matrix[row, col] == 'T')
            {
                col--;
                if (col < 0)
                {
                    col = matrix.GetLength(0) - 1;
                }
                matrix[row, col] = 'f';
            }
            else
            {
                matrix[row,col] = 'f';  
            }
        }
        static void MoveLeft(int row,int col)
        {
            matrix[row, col] = '-';
            col--;
           
            if (col < 0)
            {
                col = matrix.GetLength(0) - 1;
            }
            if (matrix[row, col] == 'F')
            {
                matrix[row, col] = 'f';
                IsWon = true;
                return;
            }
            else if (matrix[row, col] == 'B')
            {
                col--;
                if (col < 0)
                {
                    col = matrix.GetLength(0) - 1;
                }
                matrix[row, col] = 'f';
            }
            else if (matrix[row, col] == 'T')
            {
                col++;
                if (col > matrix.GetLength(0) - 1)
                {
                    col = 0;
                }
                matrix[row, col] = 'f';
            }
            else
            {
                matrix[row, col] = 'f';
            }   
        }
        static int[] FindCoordinates(char currChar)
        {
            int[] coordinates = new int[2];
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (matrix[r, c] == currChar)
                    {
                        coordinates[0] = r;
                        coordinates[1] = c;
                    }
                }
            }
            return coordinates;
        }
     
    }
}

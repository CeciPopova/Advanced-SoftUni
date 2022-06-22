using System;

namespace P02.Super_Mario
{
    internal class Program
    {
        private static char[][] matrix;
        private static int lives;
        private static int row;
        private static int col;
        private static bool isEnd = false;
        static void Main(string[] args)
        {
            lives = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            matrix = new char[rows][];
            for (int r = 0; r < rows; r++)
            {
                string input = Console.ReadLine();
                char[] chars = input.ToCharArray();
                matrix[r] = chars;
            }
            row = 0;
            col = 0;
            while (lives > 0)
            {
                string command = Console.ReadLine();
                string[] cmndArgs = command.Split(' ');
                string direction = cmndArgs[0];
                int rowB = int.Parse(cmndArgs[1]);
                int colB = int.Parse(cmndArgs[2]);
                matrix[rowB][colB] = 'B';

                lives--;
                int[] coordinates = FindMarioCoordinates();
                row = coordinates[0];
                col = coordinates[1];

                if (direction == "W")//up
                {
                    if (IsValid(row - 1, col))
                    {
                        matrix[row][col] = '-';
                        row--;
                        Move();
                    }
                }
                else if (direction == "S")//down
                {
                    if (IsValid(row + 1, col))
                    {
                        matrix[row][col] = '-';
                        row++;
                        Move();
                    }
                }
                else if (direction == "A")//left
                {
                    if (IsValid(row, col - 1))
                    {
                        matrix[row][col] = '-';
                        col--;
                        Move();
                    }
                }
                else if (direction == "D")//right
                {
                    if (IsValid(row, col + 1))
                    {
                        matrix[row][col] = '-';
                        col++;
                        Move();
                    }
                }
                if (isEnd)
                {
                    PrintMatrix();
                    return;
                }
            }
            if (lives <= 0)
            {
                matrix[row][col] = 'X';
                Console.WriteLine($"Mario died at {row};{col}.");
                PrintMatrix();
            }

        }
        static void PrintMatrix()
        {
            for (int r = 0; r < matrix.Length; r++)
            {
                for (int c = 0; c < matrix[r].Length; c++)
                {
                    Console.Write(matrix[r][c]);
                }
                Console.WriteLine();
            }
        }
        static void Move()
        {
            if (matrix[row][col] == 'B')
            {
                lives -= 2;
                if (lives <= 0)
                {
                    matrix[row][col] = 'X';
                    Console.WriteLine($"Mario died at {row};{col}.");
                    isEnd = true;
                    return;
                }
                else
                {
                    matrix[row][col] = 'M';
                }
            }
            else if (matrix[row][col] == 'P')
            {
                matrix[row][col] = '-';
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
                isEnd = true;
                return;
            }
            else
            {
                matrix[row][col] = 'M';
            }
        }
        static bool IsValid(int row, int col)
        {
            if (row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length)
            {
                return true;
            }
            return false;
        }
        static int[] FindMarioCoordinates()
        {
            int[] coordinates = new int[2];
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'M')
                    {
                        coordinates[0] = i;
                        coordinates[1] = j;
                    }
                }
            }
            return coordinates;
        }
    }
}

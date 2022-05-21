using System;
using System.Linq;

namespace P02._Squares_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixDementions = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = matrixDementions[0];
            int cols = matrixDementions[1];
            char[,] matrix = new char[rows, cols];
            for (int r = 0; r < rows; r++)
            {
                char[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int c = 0; c < cols; c++)
                {
                    matrix[r, c] = input[c];
                }
            }
            int count = 0;
            for (int r = 0; r < rows - 1; r++)
            {
                for (int c = 0; c < cols - 1; c++)
                {
                    if (matrix[r, c] == matrix[r + 1, c] && matrix[r, c] == matrix[r, c + 1] && matrix[r, c] == matrix[r + 1, c + 1])
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}

using System;
using System.Linq;

namespace P03._Maximal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixDementions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = matrixDementions[0];
            int cols = matrixDementions[1];
            int[,] matrix = new int[rows, cols];
            for (int r = 0; r < rows; r++)
            {
                int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int c = 0; c < cols; c++)
                {
                    matrix[r, c] = input[c];
                }
            }
            int sum = 0;
            int maxSum = 0;
            int maxRow = 0;
            int maxCol = 0;
            for (int r = 0; r < rows - 2; r++)
            {
                for (int c = 0; c < cols - 2; c++)
                {
                    sum = matrix[r, c] + matrix[r + 1, c] + matrix[r + 2, c] + matrix[r, c + 1] + matrix[r, c + 2] + matrix[r + 1, c + 1] + matrix[r + 2, c + 2] + matrix[r + 1, c + 2] + matrix[r + 2, c + 1];
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxRow = r;
                        maxCol = c;
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            for (int i = maxRow; i < maxRow + 3; i++)
            {
                for (int j = maxCol; j < maxCol + 3; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

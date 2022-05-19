using System;
using System.Linq;

namespace P05._Square_With_Maximum_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] matrixSize = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = matrixSize[0];
            int cols = matrixSize[1];
            int[,] matrix = new int[rows, cols];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                int[] colElements = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colElements[col];

                }
            }
            int sum = 0;
            int maxSum = 0;
            int[,] newMatrix = new int[2, 2]; 
            for (int row = 0; row < matrix.GetLength(0)-1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1)-1; col++)
                {
                    sum = matrix[row, col] + matrix[row+1, col] + matrix[row, col+1] + matrix[row+1, col+1];


                    if (sum>maxSum)
                    {
                        maxSum = sum;
                        newMatrix[0, 0] = matrix[row, col];
                        newMatrix[1, 0] = matrix[row+1, col];
                        newMatrix[0, 1] = matrix[row, col+1];
                        newMatrix[1, 1] = matrix[row + 1, col + 1];
                    }
                }
            }
            for (int i = 0; i < newMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < newMatrix.GetLength(1); j++)
                {
                    Console.Write(newMatrix[i,j]+" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(maxSum);
        }
    }
}

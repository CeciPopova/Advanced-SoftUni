using System;
using System.Linq;

namespace P02._Sum_Matrix_Columns
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

                int[] colElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colElements[col];

                }
            }
            
            for (int row = 0; row < matrix.GetLength(1); row++)
            {
                int sum = 0;
                for (int col = 0; col < matrix.GetLength(0); col++)
                {
                    sum += matrix[col, row];
                }
                Console.WriteLine(sum);
            }
        }
    }
}

using System;
using System.Linq;
using System.Text;

namespace P08._Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                int[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = input[c];
                }
            }
            string[] cordinates = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .ToArray();
            for (int i = 0; i < cordinates.Length; i++)
            {
                string bomb = cordinates[i];
                string[] bombArgs = bomb.Split(",", StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(bombArgs[0]);
                int col = int.Parse(bombArgs[1]);

                if (matrix[row, col] > 0)
                {
                    int bombValue = matrix[row, col];
                    matrix[row, col] = 0;
                    if (col - 1 >= 0)
                    {
                        if (matrix[row, col - 1] > 0)
                        {
                            matrix[row, col - 1] -= bombValue;
                        }
                    }
                    if (col + 1 < matrix.GetLength(1))
                    {
                        if (matrix[row, col + 1] > 0)
                        {
                            matrix[row, col + 1] -= bombValue;
                        }
                    }
                    if (row - 1 >= 0)
                    {
                        if (matrix[row - 1, col] > 0)
                        {
                            matrix[row - 1, col] -= bombValue;
                        }
                        if (col - 1 >= 0)
                        {
                            if (matrix[row - 1, col - 1] > 0)
                            {
                                matrix[row - 1, col - 1] -= bombValue;
                            }

                        }
                        if (col + 1 < matrix.GetLength(0))
                        {
                            if (matrix[row - 1, col + 1] > 0)
                            {
                                matrix[row - 1, col + 1] -= bombValue;

                            }

                        }
                    }
                    if (row + 1 < matrix.GetLength(0))
                    {
                        if (matrix[row + 1, col] > 0)
                        {
                            matrix[row + 1, col] -= bombValue;
                        }
                        if (col - 1 >= 0)
                        {
                            if (matrix[row + 1, col - 1] > 0)
                            {
                                matrix[row + 1, col - 1] -= bombValue;
                            }
                        }
                        if (col + 1 < matrix.GetLength(1))
                        {
                            if (matrix[row + 1, col + 1] > 0)
                            {
                                matrix[row + 1, col + 1] -= bombValue;
                            }
                        }
                    }
                }
            }
            int count = 0;
            int sum = 0;
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (matrix[r, c] > 0)
                    {
                        count++;
                        sum += matrix[r, c];
                    }
                }
            }
            Console.WriteLine($"Alive cells: {count}");
            Console.WriteLine($"Sum: {sum}");
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    Console.Write(matrix[r, c] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

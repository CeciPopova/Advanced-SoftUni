using System;
using System.Linq;

namespace P01._Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            for (int r = 0; r < n; r++)
            {
                int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int c = 0; c < n; c++)
                {
                    matrix[r, c] = input[c];
                }

            }
            int sum1 = 0;
            int sum2 = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        sum1 += matrix[i, j];
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = n - 1 - i; j >= 0; j--)
                {
                    sum2 += matrix[i, j];
                    break;
                }
            }
            int diff = Math.Abs(sum1 - sum2);
            Console.WriteLine(diff);
        }
    }
}

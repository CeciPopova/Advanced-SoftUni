using System;
using System.Linq;

namespace P05._Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixDemension = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            char[,] matrix = new char[matrixDemension[0], matrixDemension[1]];
            string snake = Console.ReadLine();  

            int index = 0;  

            for (int r = 0; r < matrixDemension[0]; r++)
            {
                if (r%2==0)
                {
                    for (int c = 0; c < matrixDemension[1]; c++)
                    {
                        matrix[r, c] = snake[index];
                        index++;
                        if (index>=snake.Length)
                        {
                            index = 0;
                        }
                    }
                }
                else
                {
                    for (int c = matrixDemension[1]-1; c >=0; c--)
                    {
                        matrix[r,c] = snake[index];
                        index++;
                        if (index>=snake.Length)
                        {
                            index = 0;
                        }
                    }
                }
               
            }

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    Console.Write(matrix[r, c]);
                }
                Console.WriteLine();
            }
        }
    }
}

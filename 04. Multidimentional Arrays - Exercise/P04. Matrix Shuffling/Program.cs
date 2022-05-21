using System;
using System.Linq;

namespace P04._Matrix_Shuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixDemension = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string[,] matrix = new string[matrixDemension[0], matrixDemension[1]];

            for (int r = 0; r < matrixDemension[0]; r++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int c = 0; c < matrixDemension[1]; c++)
                {
                    matrix[r, c] = input[c];
                }
            }
            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] cmndArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (cmndArgs[0] == "swap" && cmndArgs.Length == 5)
                {
                    int row1 = int.Parse(cmndArgs[1]);
                    int col1 = int.Parse(cmndArgs[2]);

                    int row2 = int.Parse(cmndArgs[3]);
                    int col2 = int.Parse(cmndArgs[4]);
                   
                    if (IsValid(matrix,row1,col1)==true && IsValid(matrix,row2,col2)==true)
                    {
                       string first = matrix[row1,col1];    
                       string second = matrix[row2,col2];  
                        matrix[row1,col1] = second;
                        matrix[row2,col2] = first;

                        for (int r = 0; r < matrix.GetLength(0); r++)
                        {
                            for (int c = 0; c < matrix.GetLength(1); c++)
                            {
                                Console.Write(matrix[r, c] + " ");
                            }
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                   
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }


                command = Console.ReadLine();
            }

        }
        static bool IsValid(string[,] matrix, int row, int col)
        {
            bool isValid = false;
            if (row>=0 && row<matrix.GetLength(0) && col>=0 && col<matrix.GetLength(1))
            {
                isValid = true;
            }
            return isValid; 
        }
    }
}

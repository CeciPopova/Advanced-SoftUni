using System;
using System.Linq;

namespace P06._Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int rows = int.Parse(Console.ReadLine());

            int[][] matrix = new int[rows][];
            for (int r = 0; r < rows; r++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                matrix[r] = input; 

            }
            for (int r = 0; r < rows - 1; r++)
            {
               
                if (matrix[r].Length==matrix[r+1].Length)
                {
                    matrix[r] = matrix[r].Select(x => x * 2).ToArray();
                    matrix[r + 1] = matrix[r + 1].Select(x => x * 2).ToArray();

                }
                else
                {
                    matrix[r] = matrix[r].Select(x => x / 2).ToArray();
                    matrix[r + 1] = matrix[r + 1].Select(x => x / 2).ToArray();
                }
            }
            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] cmndArgs = command.Split().ToArray();
                string action = cmndArgs[0];
                if (action == "Add")
                {
                    int row = int.Parse(cmndArgs[1]);
                    int col = int.Parse(cmndArgs[2]);
                    int value = int.Parse(cmndArgs[3]);
                    if (row >= 0 && row < rows && col >= 0 && col < matrix[row].Length)
                    {
                        matrix[row][col] += value;
                    }

                }
                else if (action == "Subtract")
                {
                    int row = int.Parse(cmndArgs[1]);
                    int col = int.Parse(cmndArgs[2]);
                    int value = int.Parse(cmndArgs[3]);
                    if (row >= 0 && row < rows && col >= 0 && col < matrix[row].Length)
                    {
                        matrix[row][col] -= value;
                    }
                }


                command = Console.ReadLine();
            }
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}

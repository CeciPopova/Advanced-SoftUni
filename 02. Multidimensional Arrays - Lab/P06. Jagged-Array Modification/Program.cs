using System;
using System.Linq;

namespace P06._Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] jaggedArr = new int[n][];
            for (int i = 0; i < n; i++)
            {
                jaggedArr[i]=Console.ReadLine().Split().Select(int.Parse).ToArray();

            }
            string command = Console.ReadLine();
            while (command!="END")
            {
                string[] commandArgs = command.Split();
                string action = commandArgs[0];
                if (action == "Add")
                {
                    int row = int.Parse(commandArgs[1]);
                    int col = int.Parse(commandArgs[2]);
                    int value = int.Parse(commandArgs[3]);
                    if (row < 0 || row >= n || col<0 ||col >= jaggedArr[row].Length)
                    {
                        Console.WriteLine("Invalid coordinates");

                    }
                    else
                    {
                        jaggedArr[row][col] += value;
                    }
                }
                else if (action == "Subtract")
                {
                    int row = int.Parse(commandArgs[1]);
                    int col = int.Parse(commandArgs[2]);
                    int value = int.Parse(commandArgs[3]);
                    if (row<0 || row>=n||col<0 ||col>=jaggedArr[row].Length)
                    {
                        Console.WriteLine("Invalid coordinates");

                    }
                    else
                    {
                        jaggedArr[row][col] -= value;
                    }
                }

                command = Console.ReadLine();
            }
            for (int row = 0; row < jaggedArr.GetLength(0); row++)
            {
                Console.WriteLine(String.Join(" ", jaggedArr[row]));
            }
        }
    }
}

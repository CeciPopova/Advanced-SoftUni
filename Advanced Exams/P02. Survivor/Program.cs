using System;
using System.Collections.Generic;

namespace _02.Survivor
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int opponentTokens = 0;
            int myTokens = 0;
            int beachRows = int.Parse(Console.ReadLine());
            string[][] beach = new string[beachRows][];
            for (int i = 0; i < beachRows; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                beach[i] = input;
            }
            string command = Console.ReadLine();
            while (command != "Gong")
            {
                string[] cmndArgs = command.Split(' ');
                string action = cmndArgs[0];
                int row = int.Parse(cmndArgs[1]);
                int col = int.Parse(cmndArgs[2]);
                if (action == "Find")
                {
                    myTokens=CollectTokens(beach, row, col, myTokens);
                }
                else if (action == "Opponent")
                {
                    string direction = cmndArgs[3];
                    if (!IsValid(beach,row,col))
                    {
                        command=Console.ReadLine(); 
                        continue;
                    }
                    for (int i = 0; i <= 3; i++)
                    {
                        if (direction == "up")
                        {
                            opponentTokens = CollectTokens(beach, row-i, col, opponentTokens);
                        }
                        else if (direction == "down")
                        {
                            opponentTokens = CollectTokens(beach, row+i, col, opponentTokens);
                        }
                        else if (direction == "left")
                        {
                            opponentTokens = CollectTokens(beach, row, col-i, opponentTokens);
                        }
                        else if (direction == "right")
                        {
                            opponentTokens = CollectTokens(beach, row, col+i, opponentTokens);
                        }
                    }
                }
                command = Console.ReadLine();
            }
            for (int i = 0; i < beachRows; i++)
            {
                Console.WriteLine(string.Join(" ", beach[i]));
            }
            Console.WriteLine($"Collected tokens: {myTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");
        }
        static int CollectTokens(string[][] beach, int row, int col, int tokens)
        {
            int count = tokens;
            if (IsValid(beach, row, col))
            {
                if (beach[row][col] == "T")
                {
                    count++;
                    beach[row][col] = "-";
                }
            }
            return count;
        }
        static bool IsValid(string[][] matrix, int row, int col)
        {
            bool isValid = false;
            if (row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length)
            {
                isValid = true;
            }
            return isValid;
        }
    }
}

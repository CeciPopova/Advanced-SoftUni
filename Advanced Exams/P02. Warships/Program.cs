using System;
using System.Collections.Generic;
using System.Linq;

namespace P02._Warships
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int firstPlayerShips = 0;
            int secondPlayerShips = 0;
            int totalShipsDestroyed = 0;
            char[,] matrix = new char[size, size];
            string[] attackCommands = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).ToArray();
            for (int r = 0; r < size; r++)
            {
                char[] chars = Console.ReadLine().Split().Select(char.Parse).ToArray();
                for (int c = 0; c < size; c++)
                {
                    matrix[r, c] = chars[c];
                    if (matrix[r, c] == '<')
                    {
                        firstPlayerShips++;
                    }
                    else if (matrix[r, c] == '>')
                    {
                        secondPlayerShips++;
                    }
                }
            }

            for (int i = 0; i < attackCommands.Length; i++)
            {
                if (firstPlayerShips <= 0 || secondPlayerShips <= 0)
                {
                    break;
                }
                string input = attackCommands[i];
                int[] coordinates = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int row = coordinates[0];
                int col = coordinates[1];

                if (!IsValid(matrix, row, col))
                {
                    continue;
                }
                else if (matrix[row, col] == '#')
                {
                    matrix[row, col] = 'X';
                    if (row - 1 >= 0)
                    {
                        if (matrix[row - 1, col] == '<')
                        {
                            firstPlayerShips--;
                            totalShipsDestroyed++;
                        }
                        else if (matrix[row - 1, col] == '>')
                        {
                            secondPlayerShips--;
                            totalShipsDestroyed++;
                        }
                        matrix[row - 1, col] = 'X';

                    }
                    if (row + 1 < size)
                    {
                        if (matrix[row + 1, col] == '<')
                        {
                            firstPlayerShips--;
                            totalShipsDestroyed++;
                        }
                        else if (matrix[row + 1, col] == '>')
                        {
                            secondPlayerShips--;
                            totalShipsDestroyed++;
                        }
                        matrix[row + 1, col] = 'X';
                    }
                    if (col - 1 >= 0)
                    {
                        if (matrix[row, col - 1] == '<')
                        {
                            firstPlayerShips--;
                            totalShipsDestroyed++;
                        }
                        else if (matrix[row, col - 1] == '>')
                        {
                            secondPlayerShips--;
                            totalShipsDestroyed++;
                        }
                        matrix[row, col - 1] = 'X';
                    }
                    if (col + 1 < size)
                    {
                        if (matrix[row, col + 1] == '<')
                        {
                            firstPlayerShips--;
                            totalShipsDestroyed++;
                        }
                        else if (matrix[row, col + 1] == '>')
                        {
                            secondPlayerShips--;
                            totalShipsDestroyed++;
                        }
                        matrix[row, col + 1] = 'X';
                    }
                    if (row + 1 < size && col + 1 < size)
                    {
                        if (matrix[row + 1, col + 1] == '<')
                        {
                            firstPlayerShips--;
                            totalShipsDestroyed++;
                        }
                        else if (matrix[row + 1, col + 1] == '>')
                        {
                            secondPlayerShips--;
                            totalShipsDestroyed++;
                        }
                        matrix[row + 1, col + 1] = 'X';
                    }
                    if (row + 1 < size && col - 1 >= 0)
                    {
                        if (matrix[row + 1, col - 1] == '<')
                        {
                            firstPlayerShips--;
                            totalShipsDestroyed++;
                        }
                        else if (matrix[row + 1, col - 1] == '>')
                        {
                            secondPlayerShips--;
                            totalShipsDestroyed++;
                        }
                        matrix[row + 1, col - 1] = 'X';
                    }
                    if (row - 1 >= 0 && col - 1 >= 0)
                    {
                        if (matrix[row - 1, col - 1] == '<')
                        {
                            firstPlayerShips--;
                            totalShipsDestroyed++;
                        }
                        else if (matrix[row - 1, col - 1] == '>')
                        {
                            secondPlayerShips--;
                            totalShipsDestroyed++;
                        }
                        matrix[row - 1, col - 1] = 'X';
                    }
                    if (row - 1 >= 0 && col + 1 < size)
                    {
                        if (matrix[row - 1, col + 1] == '<')
                        {
                            firstPlayerShips--;
                            totalShipsDestroyed++;
                        }
                        else if (matrix[row - 1, col + 1] == '>')
                        {
                            secondPlayerShips--;
                            totalShipsDestroyed++;
                        }
                        matrix[row - 1, col + 1] = 'X';
                    }

                }
                else if (matrix[row, col] == '<')
                {
                    firstPlayerShips--;
                    totalShipsDestroyed++;
                    matrix[row, col] = 'X';
                }
                else if (matrix[row, col] == '>')
                {
                    secondPlayerShips--;
                    totalShipsDestroyed++;
                    matrix[row, col] = 'X';
                }
              
                if (firstPlayerShips <= 0 || secondPlayerShips <= 0)
                {
                    break;
                }

            }
            if (secondPlayerShips == 0)
            {
                Console.WriteLine($"Player One has won the game! {totalShipsDestroyed} ships have been sunk in the battle.");
            }
            else if (firstPlayerShips == 0)
            {
                Console.WriteLine($"Player Two has won the game! {totalShipsDestroyed} ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {firstPlayerShips} ships left. Player Two has {secondPlayerShips} ships left.");
            }
        }
        static bool IsValid(char[,] matrix, int row, int col)
        {
            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }
    }
}

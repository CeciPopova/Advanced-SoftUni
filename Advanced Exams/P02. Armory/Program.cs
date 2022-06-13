using System;
using System.Linq;

namespace P02._Armory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] armory = new char[n, n];
          
            int goldCoins = 0;

            for (int r = 0; r < n; r++)
            {
                string input = Console.ReadLine();
                for (int c = 0; c < n; c++)
                {
                    armory[r, c] = input[c];
                  
                }
            }
            string command = Console.ReadLine();
            while (goldCoins <= 65)
            {
                int row = 0;
                int col = 0;
                bool isFound = false;   
                for (int r = 0; r < n; r++)
                {
                    for (int c = 0; c < n; c++)
                    {
                        if (armory[r, c] == 'A')
                        {
                            row = r;
                            col = c;
                            isFound = true;
                            break;
                        }
                    }
                    if (isFound)
                    {
                        break;
                    }
                }
                if (command == "up")
                {
                    if (row - 1 < 0)
                    {
                        armory[row, col] = '-';
                        break;
                        
                    }
                    else
                    {
                       goldCoins = MoveUp(armory, row, col, goldCoins);
                    }

                }
                else if (command == "down")
                {
                    if (row + 1 >= armory.GetLength(0))
                    {
                        armory[row, col] = '-';
                        break;
                    }
                    else
                    {
                        goldCoins = MoveDown(armory, row, col, goldCoins);
                    }
                }
                else if (command == "right")
                {
                    if (col + 1 >= armory.GetLength(1))
                    {
                        armory[row, col] = '-';
                        break;
                    }
                    else
                    {
                        goldCoins = MoveRight(armory, row, col, goldCoins);
                    }
                }
                else if (command == "left")
                {
                    if (col - 1 < 0)
                    {
                        armory[row, col] = '-';
                        break;
                    }
                    else
                    {
                        goldCoins = MoveLeft(armory, row, col, goldCoins);
                    }
                }
                command = Console.ReadLine();
            }
            if (goldCoins<65)
            {
                Console.WriteLine("I do not need more swords!");
            }
            else
            {
                Console.WriteLine("Very nice swords, I will come back for more!");
            }
            Console.WriteLine($"The king paid {goldCoins} gold coins.");



            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    Console.Write(armory[r, c]);
                }
                Console.WriteLine();
            }

        }
        static int MoveUp(char[,] matrix, int row, int col, int gold)
        {
            if (char.IsDigit(matrix[row - 1, col]))
            {
                gold += (int)matrix[row - 1, col] - '0';
                matrix[row, col] = '-';
                matrix[row - 1, col] = 'A';
             
            }
            else if (matrix[row - 1, col] == 'M')
            {
                int mirrorCol = 0;
                int mirrorRow = 0;
                for (int r = 0; r < matrix.GetLength(0); r++)
                {
                    for (int c = 0; c < matrix.GetLength(1); c++)
                    {
                        if (r != row - 1 && matrix[r, c] == 'M')
                        {
                            mirrorRow = r;
                            mirrorCol = c;
                        }
                    }
                }
                matrix[row, col] = '-';
                matrix[row - 1, col] = '-';
                matrix[mirrorRow, mirrorCol] = 'A';
              
            }
            else if (matrix[row - 1, col] == '-')
            {
                matrix[row, col] = '-';
                matrix[row - 1, col] = 'A';
            }
            return gold;
        }
        static int MoveDown(char[,] matrix, int row, int col, int gold)
        {
            if (char.IsDigit(matrix[row + 1, col]))
            {
                gold += (int)matrix[row + 1, col] - '0';
                matrix[row, col] = '-';
                matrix[row + 1, col] = 'A';
               
            }
            else if (matrix[row + 1, col] == 'M')
            {
                int mirrorCol = 0;
                int mirrorRow = 0;
                for (int r = 0; r < matrix.GetLength(0); r++)
                {
                    for (int c = 0; c < matrix.GetLength(1); c++)
                    {
                        if (r != row + 1 && matrix[r, c] == 'M')
                        {
                            mirrorRow = r;
                            mirrorCol = c;
                        }
                    }
                }
                matrix[row,col] = '-';  
                matrix[row + 1, col] = '-';
                matrix[mirrorRow, mirrorCol] = 'A';

            }
            else if (matrix[row + 1,col] == '-')
            {
                matrix[row, col] = '-';
                matrix[row + 1, col] = 'A';
            }
            return gold;
        }
        static int MoveRight(char[,] matrix, int row, int col, int gold)
        {
            if (char.IsDigit(matrix[row, col + 1]))
            {
                gold += matrix[row, col + 1]-'0';
                matrix[row, col] = '-';
                matrix[row, col + 1] = 'A';
              
            }
            else if (matrix[row, col + 1] == 'M')
            {
                int mirrorCol = 0;
                int mirrorRow = 0;
                for (int r = 0; r < matrix.GetLength(0); r++)
                {
                    for (int c = 0; c < matrix.GetLength(1); c++)
                    {
                        if (c != col + 1 && matrix[r, c] == 'M')
                        {
                            mirrorRow = r;
                            mirrorCol = c;
                        }
                    }
                }
                matrix[row, col] = '-';
                matrix[row, col + 1] = '-';
                matrix[mirrorRow, mirrorCol] = 'A';
               
            }
            else if (matrix[row , col +1] == '-')
            {
                matrix[row, col] = '-';
                matrix[row, col +1] = 'A';
            }
            return gold;
        }
        static int MoveLeft(char[,] matrix, int row, int col, int gold)
        {
            if (char.IsDigit(matrix[row , col - 1]))
            {
                gold += (int)matrix[row, col - 1] - '0';
                matrix[row, col] = '-';
                matrix[row, col - 1] = 'A';
               
            }
            else if (matrix[row, col - 1] == 'M')
            {
                int mirrorCol = 0;
                int mirrorRow = 0;
                for (int r = 0; r < matrix.GetLength(0); r++)
                {
                    for (int c = 0; c < matrix.GetLength(1); c++)
                    {
                        if (c!=c-1 && matrix[r, c] == 'M')
                        {
                            mirrorRow = r;
                            mirrorCol = c;
                        }
                    }
                }
                matrix[row , col] = '-';    
                matrix[row, col - 1] = '-';
                matrix[mirrorRow, mirrorCol] = 'A';
              
            }
            else if (matrix[row , col-1] == '-')
            {
                matrix[row, col] = '-';
                matrix[row , col-1] = 'A';
            }
            return gold;
        }
    }
}

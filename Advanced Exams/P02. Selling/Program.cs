using System;

namespace P02._Selling
{
    internal class Program
    {
        private static char[,] matrix;
        private static int row;
        private static int col; 
        private static int totalMoneyCollect;    
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            matrix = new char[n, n];
            totalMoneyCollect = 0;
           
            for (int r = 0; r < n; r++)
            {
                string input = Console.ReadLine();
                for (int c = 0; c < n; c++)
                {
                    matrix[r, c] = input[c];
                    if (matrix[r,c]=='S')
                    {
                        row = r;
                        col = c;    
                    }
                }
            }
           
            while (totalMoneyCollect<50 )
            {
                string command = Console.ReadLine();
                if (command=="up")
                {
                    matrix[row, col] = '-';
                    row--;
                    if (row<0)
                    {
                        break;
                    }
                    else
                    {
                        Move();
                    }
                }
                else if (command=="down")
                {
                    matrix[row, col] = '-';
                    row++;
                    if (row>=matrix.GetLength(0))
                    {
                        break;
                    }
                    else
                    {
                        Move();
                    }
                }
                else if (command == "left")
                {
                    matrix[row, col] = '-';
                    col--;
                    if (col<0)
                    {
                        break;
                    }
                    else
                    {
                        Move();
                    }

                }
                else if (command=="right")
                {
                    matrix[row, col] = '-';
                    col++;
                    if (col>=matrix.GetLength(1))
                    {
                        break;
                    }
                    else
                    {
                        Move();
                    }

                }
            }
            if (totalMoneyCollect<50)
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
            }
            else
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }
            Console.WriteLine($"Money: {totalMoneyCollect}");
            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    Console.Write(matrix[r,c]);
                }
                Console.WriteLine();
            }
        }
        static void Move()
        {
            if (matrix[row, col] == 'O')
            {
                matrix[row, col] = '-';
                int[] coordinares = FindCoordinates(matrix, 'O');

                row = coordinares[0];
                col = coordinares[1];
                matrix[row, col] = 'S';
            }
            else if (char.IsDigit(matrix[row, col]))
            {
               int value = matrix[row, col] - '0';
               totalMoneyCollect+=value;
                matrix[row, col] = 'S';
            }
            else
            {
                matrix[row, col] = 'S';
            }
        }
        static int[] FindCoordinates(char[,] matrix, char currChar)
        {
            int[] coordinates = new int[2];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] == currChar)
                    {
                        coordinates[0] = i;
                        coordinates[1] = j;
                    }
                }
            }
            return coordinates;
        }
       
    }
}

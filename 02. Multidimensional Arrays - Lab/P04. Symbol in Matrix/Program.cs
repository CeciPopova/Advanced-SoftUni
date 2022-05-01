using System;
using System.Linq;

namespace P04._Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            for (int row = 0; row < n; row++)
            {
                string colElements = Console.ReadLine();
                for (int col = 0; col < colElements.Length; col++)
                {
                    matrix[row, col] = colElements[col];    
                }
            }
            char charToFind = char.Parse(Console.ReadLine());
            int currRow = 0;    
            int currCol = 0; 
            bool isFound = false;   
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {

                    if (matrix[row, col] == charToFind)
                    {
                        currRow = row;  
                        currCol = col;  
                        isFound = true;
                        break;
                    }
                }
                if (isFound==true)
                {
                    break;
                }
            }
            if (isFound)
            {
                Console.WriteLine($"({currRow}, {currCol})");
            }
            else
            {
                Console.WriteLine($"{charToFind} does not occur in the matrix");
            }

    
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace P02._Truffle_Hunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int n = int.Parse(Console.ReadLine());
            char[,] truffleForest = new char[n,n];
            int blackTruffles = 0;
            int summerTruffles = 0;
            int whiteTruffles = 0;  
            for (int r = 0; r < n; r++)
            {
                char[] input = Console.ReadLine()
                    .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();  
                for (int c = 0; c < n; c++)
                {
                    truffleForest[r,c] = input[c]; 
                }
            }
            int boarTruffles = 0;
            string command = Console.ReadLine();    
            while  (command != "Stop the hunt" )
            {
                string[] cmndArgs = command.Split(' '); 
                string action = cmndArgs[0];
                int row = int.Parse(cmndArgs[1]);
                int col = int.Parse(cmndArgs[2]);
                if (action=="Collect")
                {
                   
                    if (IsValid(row,col,truffleForest))
                    {
                        char currChar = truffleForest[row,col];
                        if (currChar=='B')
                        {
                            blackTruffles++;
                        }
                        else if (currChar=='S')
                        {
                            summerTruffles++;
                        }
                        else if (currChar=='W')
                        {
                            whiteTruffles++;
                        }
                        truffleForest[row,col] = '-';
                    }
                }
                else if (action== "Wild_Boar")
                {
                    char boarStartIndex=truffleForest[row,col];
                    if (boarStartIndex == '-')
                    {
                        command=Console.ReadLine(); 
                        continue;
                    }
                    else
                    {
                        string direction = cmndArgs[3];
                        if (direction == "up")
                        {
                            for (int i = row; i >= 0; i-=2)
                            {
                                if (truffleForest[i,col]!='-')
                                {
                                    boarTruffles++;
                                    truffleForest[i, col] = '-';
                                }
                               
                            }
                        }
                        else if (direction == "down")
                        {
                            for (int i = row; i < truffleForest.GetLength(1); i+=2)
                            {
                                if (truffleForest[i,col]!='-')
                                {
                                    boarTruffles++;
                                    truffleForest[i,col]= '-';
                                }
                            }
                        }
                        else if (direction == "left")
                        {
                            for (int i = col; i > 0; i-=2)
                            {
                                if (truffleForest[row,i]!='-')
                                {
                                    boarTruffles++;
                                    truffleForest[row,i]= '-';
                                }
                            }
                        }
                        else if (direction == "right")
                        {
                            for (int i = col; i < truffleForest.GetLength(0); i+=2)
                            {
                                if (truffleForest[row,i]!='-')
                                {
                                    boarTruffles++;
                                    truffleForest[row,i]='-';
                                }
                            }

                        }
                    }

                }

                command = Console.ReadLine();   
            }
            Console.WriteLine($"Peter manages to harvest {blackTruffles} black, {summerTruffles} summer, and {whiteTruffles} white truffles.");
            Console.WriteLine($"The wild boar has eaten {boarTruffles} truffles.");
            PrintMatrix(truffleForest);
        }
      
        static bool IsValid(int row,int col,char[,] matrix)
        {
            bool isValid = false;   
            if (row>=0 && row<matrix.GetLength(0) && col>=0 && col<matrix.GetLength(1))
            {
                isValid = true;
            }
            return isValid; 
        }
        static void PrintMatrix(char[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    Console.Write(matrix[r, c] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

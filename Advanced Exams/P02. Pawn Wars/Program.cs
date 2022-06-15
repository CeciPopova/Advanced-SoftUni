using System;
using System.Linq;

namespace P02._Pawn_Wars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] chessboard = new char[8, 8];
            for (int r = 0; r < 8; r++)
            {
                string input = Console.ReadLine();
                for (int c = 0; c < 8; c++)
                {
                    chessboard[r, c] = input[c];    
                }
            }
            char white = 'w';
            char black = 'b';
            int count = 0;

            int[] whiteCordinates = FindPawn(chessboard, white);
            int whiteRow = whiteCordinates[0];
            int whiteColl = whiteCordinates[1];
            int[] blackCordinates = FindPawn(chessboard, black);
            int blackRow = blackCordinates[0];
            int blackColl = blackCordinates[1];
            while (whiteRow>0 && blackRow<7)
            {
                count++;
                
                whiteCordinates = FindPawn(chessboard, white); 
                whiteRow= whiteCordinates[0];   
                whiteColl = whiteCordinates[1]; 
                blackCordinates = FindPawn(chessboard, black);
                blackRow= blackCordinates[0];   
                blackColl = blackCordinates[1];

                if (count%2!=0)
                {
                    chessboard[whiteRow, whiteColl] = '-';
                    if (blackRow==whiteRow-1 && (blackColl==whiteColl+1 || blackColl==whiteColl-1 || blackColl==whiteColl))
                    {
                        chessboard[blackRow, blackColl] = 'w';
                        Console.WriteLine($"Game over! White capture on {(char)(blackColl + 97)}{8 - blackRow}.");

                    }
                    else
                    {
                        chessboard[whiteRow - 1, whiteColl] = 'w';
                    }
                }
                else
                {
                    chessboard[blackRow, blackColl] = '-';
                    if (whiteRow==blackRow-1 && (whiteColl==blackColl-1 || whiteColl== blackColl+1 || whiteColl==blackColl))
                    {
                        chessboard[whiteRow, whiteColl] = 'b';
                        Console.WriteLine($"Game over! Black capture on {(char)(whiteColl + 97)}{8 - whiteRow}.");
                        break;
                    }
                    else
                    {
                        chessboard[blackRow + 1, blackColl] = 'b';
                    }
                   
                }

            }
            if (whiteRow == 0)
            {
                Console.WriteLine($"Game over! White pawn is promoted to a queen at {(char)(whiteColl + 97)}{8 - whiteRow}.");

            }
            else if (blackRow == 7)
            {
                Console.WriteLine($"Game over! Black pawn is promoted to a queen at {(char)(blackColl + 97)}{8 - blackRow}.");
               
            }
        }
        static int[] FindPawn(char[,] chessboard,char currChar)
        {
            int[] cordinates = new int[2];
          
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    if (chessboard[r,c]==currChar)
                    {
                        cordinates[0] = r;
                        cordinates[1] = c;  
                      
                    }
                }
            }
            return cordinates;  
        }
    }
}

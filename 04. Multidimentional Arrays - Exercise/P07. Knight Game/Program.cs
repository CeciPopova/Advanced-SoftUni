using System;
using System.Linq;

namespace P07._Knight_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int size = int.Parse(Console.ReadLine());
           
            char[,] board = new char[size, size];

            for (int r = 0; r < board.GetLength(0); r++)
            {
                string input = Console.ReadLine();
                for (int c = 0; c < board.GetLength(1); c++)
                {
                    board[r, c] = input[c];
                }
            }                                                             //       i   i   i   i   i    
                                                                          //       0   1   2   3   4   COL
            int attackableKnights = 0;                                    // ROW ---------------------                                      
            int maxAttackableKnights = -1;                                //  0  |   | X |   | X |   |      K --> Knight
            int bestKnightRow = 0;                                        //  1  | X |   |   |   | X |      X --> Attackable Unit (Other Knight)
            int bestKnightCol = 0;                                        //  2  |   |   | K |   |   |
            int count = 0;                                                //  3  | X |   |   |   | A |
                                                                          //  4  |   | X |   | X |   |
            while (true)                                                  //     ---------------------
            {
                for (int r = 0; r < board.GetLength(0); r++)
                {
                    for (int c = 0; c < board.GetLength(1); c++)
                    {
                        if (board[r, c] == 'K')
                        {
                            //--------- 1 row UNDER ---------
                            if (r + 1 < board.GetLength(0))
                            {
                                if (c - 2 >= 0)
                                {
                                    if (board[r + 1, c - 2] == 'K')
                                    {
                                        attackableKnights++;
                                    }
                                }

                                if (c + 2 < board.GetLength(1))
                                {
                                    if (board[r + 1, c + 2] == 'K')
                                    {
                                        attackableKnights++;
                                    }
                                }
                            }

                            //--------- 1 row UP ---------
                            if (r - 1 >= 0)
                            {
                                if (c - 2 >= 0)
                                {
                                    if (board[r - 1, c - 2] == 'K')
                                    {
                                        attackableKnights++;
                                    }
                                }

                                if (c + 2 < board.GetLength(1))
                                {
                                    if (board[r - 1, c + 2] == 'K')
                                    {
                                        attackableKnights++;
                                    }
                                }
                            }
                            //--------- 2 rows UNDER ---------
                            if (r + 2 < board.GetLength(0))
                            {
                                if (c + 1 < board.GetLength(1))
                                {
                                    if (board[r + 2, c + 1] == 'K')
                                    {
                                        attackableKnights++;
                                    }
                                }

                                if (c - 1 >= 0)
                                {
                                    if (board[r + 2, c - 1] == 'K')
                                    {
                                        attackableKnights++;
                                    }
                                }
                            }

                            //--------- 2 rows UP ---------
                            if (r - 2 >= 0)
                            {
                                if (c + 1 < board.GetLength(1))
                                {
                                    if (board[r - 2, c + 1] == 'K')
                                    {
                                        attackableKnights++;
                                    }
                                }

                                if (c - 1 >= 0)
                                {
                                    if (board[r - 2, c - 1] == 'K')
                                    {
                                        attackableKnights++;
                                    }
                                }
                            }
                        }

                        if (attackableKnights > maxAttackableKnights)
                        {
                            maxAttackableKnights = attackableKnights;
                            bestKnightRow = r;
                            bestKnightCol = c;
                        }
                        attackableKnights = 0;
                    }
                }

                if (maxAttackableKnights != 0)
                {
                    board[bestKnightRow, bestKnightCol] = '0';
                    maxAttackableKnights = 0;
                    count++;
                }
                else
                {
                    Console.WriteLine(count);
                    return;
                }
            }
        }
    }
}

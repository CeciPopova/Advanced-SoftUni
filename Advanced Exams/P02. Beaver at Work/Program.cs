using System;
using System.Collections.Generic;
using System.Linq;

namespace P02._Beaver_at_Work
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<char> woodBrnches = new List<char>();
            int n = int.Parse(Console.ReadLine());
            char[,] pond = new char[n, n];

            for (int r = 0; r < n; r++)
            {
                char[] input = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
                for (int c = 0; c < n; c++)
                {
                    pond[r, c] = input[c];
                }
            }
            string command = Console.ReadLine();
            while (command != "end")
            {
                int countWoodBranches = GetWoodBranchesCount(pond);

                if (countWoodBranches == 0)
                {
                    break;
                }
                int row = 0;
                int coll = 0;
                bool isFound = false;
                for (int r = 0; r < pond.GetLength(0); r++)
                {
                    for (int c = 0; c < pond.GetLength(1); c++)
                    {
                        if (pond[r, c] == 'B')
                        {
                            row = r;
                            coll = c;
                            isFound = true;

                        }
                        if (isFound)
                        {
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
                    GetCommandUp(pond, row, coll, woodBrnches);

                }
                else if (command == "down")
                {
                    GetCommandDown(pond, row, coll, woodBrnches);

                }
                else if (command == "right")
                {
                    GetCommandRight(pond, row, coll, woodBrnches);

                }
                else if (command == "left")
                {
                    GetCommandLeft(pond, row, coll, woodBrnches);
                }
                command = Console.ReadLine();

            }
            int count = GetWoodBranchesCount(pond);
            if (count > 0)
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {count} branches left.");
            }
            else
            {
                Console.WriteLine($"The Beaver successfully collect {woodBrnches.Count} wood branches: {string.Join(", ", woodBrnches)}.");
            }
            PrintMatrix(pond);
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
        static int GetWoodBranchesCount(char[,] matrix)
        {
            int countWoodBranches = 0;
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (char.IsLower(matrix[r, c]))
                    {
                        countWoodBranches++;
                    }
                }

            }
            return countWoodBranches;
        }

        static void GetCommandUp(char[,] matrix, int r, int c, List<char> woodBranches)
        {
            if (r - 1 < 0)
            {
                if (woodBranches.Count > 0)
                {
                    woodBranches.RemoveAt(woodBranches.Count - 1);
                }
            }
            else
            {
                if (char.IsLower(matrix[r - 1, c]))
                {
                    woodBranches.Add(matrix[r - 1, c]);
                    matrix[r - 1, c] = 'B';
                    matrix[r, c] = '-';
                }
                else if (matrix[r - 1, c] == 'F')
                {
                    if (r - 1 != 0)
                    {
                        matrix[r - 1, c] = '-';
                        if (char.IsLower(matrix[0, c]))
                        {
                            woodBranches.Add(matrix[0, c]);
                        }
                        matrix[0, c] = 'B';
                        matrix[r, c] = '-';
                    }
                    else
                    {
                        matrix[r - 1, c] = '-';
                        if (char.IsLower(matrix[matrix.GetLength(0) - 1, c]))
                        {
                            woodBranches.Add(matrix[matrix.GetLength(0) - 1, c]);
                        }
                        matrix[matrix.GetLength(0) - 1, c] = 'B';
                        matrix[r, c] = '-';
                    }
                }
                else if (matrix[r - 1, c] == '-')
                {
                    matrix[r, c] = '-';
                    matrix[r - 1, c] = 'B';
                }
            }
        }
        static void GetCommandDown(char[,] matrix, int r, int c, List<char> woodBranches)
        {

            if (r + 1 >= matrix.GetLength(0))
            {
                if (woodBranches.Count > 0)
                {
                    woodBranches.RemoveAt(woodBranches.Count - 1);
                }
            }
            else
            {
                if (char.IsLower(matrix[r + 1, c]))
                {
                    woodBranches.Add(matrix[r + 1, c]);
                    matrix[r + 1, c] = 'B';
                    matrix[r, c] = '-';
                }
                else if (matrix[r + 1, c] == 'F')
                {
                    if (r + 1 < matrix.GetLength(0))
                    {
                        matrix[r + 1, c] = '-';
                        if (char.IsLower(matrix[0, c]))
                        {
                            woodBranches.Add(matrix[matrix.GetLength(0) - 1, c]);
                        }
                        matrix[matrix.GetLength(0) - 1, c] = 'B';
                        matrix[r, c] = '-';
                    }
                    else
                    {
                        matrix[r + 1, c] = '-';
                        if (char.IsLower(matrix[0, c]))
                        {
                            woodBranches.Add(matrix[0, c]);
                        }
                        matrix[0, c] = 'B';
                        matrix[r, c] = '-';
                    }
                }
                else if (matrix[r + 1, c] == '-')
                {
                    matrix[r, c] = '-';
                    matrix[r + 1, c] = 'B';
                }
            }
        }
        static void GetCommandRight(char[,] matrix, int r, int c, List<char> woodBranches)
        {
            if (c + 1 >= matrix.GetLength(1))
            {
                if (woodBranches.Count > 0)
                {
                    woodBranches.RemoveAt(woodBranches.Count - 1);
                }
            }
            else
            {
                if (char.IsLower(matrix[r, c + 1]))
                {
                    woodBranches.Add(matrix[r, c + 1]);
                    matrix[r, c + 1] = 'B';
                    matrix[r, c] = '-';
                }
                else if (matrix[r, c + 1] == 'F')
                {
                    if (c + 1 < matrix.GetLength(1)-1)
                    {
                        matrix[r, c + 1] = '-';
                        if (char.IsLower(matrix[r, matrix.GetLength(1) - 1]))
                        {
                            woodBranches.Add(matrix[r, matrix.GetLength(1) - 1]);
                        }
                        matrix[r, matrix.GetLength(1) - 1] = 'B';
                        matrix[r, c] = '-';
                    }
                    else
                    {
                        matrix[r, c + 1] = '-';
                        if (char.IsLower(matrix[r, 0]))
                        {
                            woodBranches.Add(matrix[r, 0]);
                        }
                        matrix[r, 0] = 'B';
                        matrix[r, c] = '-';
                    }
                }
                else if (matrix[r, c + 1] == '-')
                {
                    matrix[r, c] = '-';
                    matrix[r, c + 1] = 'B';
                }
            }
        }
        static void GetCommandLeft(char[,] matrix, int r, int c, List<char> woodBranches)
        {
            if (c - 1 < 0)
            {
                if (woodBranches.Count > 0)
                {
                    woodBranches.RemoveAt(woodBranches.Count - 1);
                }
            }
            else
            {
                if (char.IsLower(matrix[r, c - 1]))
                {
                    woodBranches.Add(matrix[r, c - 1]);
                    matrix[r, c - 1] = 'B';
                    matrix[r, c] = '-';
                }
                else if (matrix[r, c - 1] == 'F')
                {
                    if (c - 1 > 0)
                    {
                        matrix[r, c - 1] = '-';
                        if (char.IsLower(matrix[r, 0]))
                        {
                            woodBranches.Add(matrix[r, 0]);
                        }
                        matrix[r, 0] = 'B';
                        matrix[r, c] = '-';
                    }
                    else
                    {
                        matrix[r, c - 1] = '-';
                        if (char.IsLower(matrix[r, matrix.GetLength(0) - 1]))
                        {
                            woodBranches.Add(matrix[r, matrix.GetLength(0) - 1]);
                        }
                        matrix[r, matrix.GetLength(0) - 1] = 'B';
                        matrix[r, c] = '-';
                    }
                }
                else if (matrix[r, c - 1] == '-')
                {
                    matrix[r, c] = '-';
                    matrix[r, c - 1] = 'B';
                }
            }

        }
    }
}

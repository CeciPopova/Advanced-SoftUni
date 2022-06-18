using System;
using System.Linq;

namespace P02._The_Battle_of_The_Five_Armies
{
    internal class Program
    {
        private static int armor;
        private static int armyRow;
        private static int armyColl;
        private static int orgsRow;
        private static int orgsColl;
        private static int mordorRow;
        private static int mordorColl;
        private static bool isEnd; 
        static void Main(string[] args)
        {
            isEnd = false;
            armor = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            char[][] land = new char[rows][];
            for (int r = 0; r < rows; r++)
            {
               string input = Console.ReadLine();
                char[] chars = input.ToCharArray();
                land[r] = chars;
            }
            string command = Console.ReadLine();
            
            while (armor>=0)
            {
              
                string[] cmndArgs = command.Split(' ');
                string direction = cmndArgs[0];
                orgsRow = int.Parse(cmndArgs[1]);
                orgsColl = int.Parse(cmndArgs[2]);
                land[orgsRow][orgsColl] = 'O';

                armor--;

                int[] mordorCoordinates = FindMordor(land);
                mordorRow = mordorCoordinates[0];
                mordorColl = mordorCoordinates[1];
                
                int[] armyCoordinates =FindArmy(land);
                armyRow = armyCoordinates[0];
                armyColl = armyCoordinates[1];  
                if (direction=="up")
                {
                    if (IsValid(land,armyRow-1,armyColl))
                    {
                        land[armyRow][armyColl]='-';
                        armyRow--;
                      Move(land);
                    }
                   
                  
                }
                else if (direction =="down")
                {
                    if (IsValid(land, armyRow + 1, armyColl))
                    {
                        land[armyRow][armyColl] = '-';
                        armyRow++;
                        Move(land);
                    }
                
                }
                else if (direction =="left")
                {
                    if (IsValid(land, armyRow , armyColl-1))
                    {
                        land[armyRow][armyColl] = '-';
                        armyColl--;
                        Move(land);
                    }
                   
                }
                else if (direction == "right")
                {
                    if (IsValid(land, armyRow , armyColl+1))
                    {
                        land[armyRow][armyColl] = '-';
                        armyColl++;
                        Move(land);
                    }
                   
                }
                if (isEnd)
                {
                    return;
                }

                command = Console.ReadLine();
            }
            
        }
        static void PrintLand(char[][] land)
        {
            for (int i = 0; i < land.Length; i++)
            {
                Console.WriteLine(String.Join("", land[i]));
            }
        }
        static void Move(char[][] land)
        {
            if (land[armyRow][armyColl]=='O')
            {
                armor -= 2;
                if (armor > 0)
                {
                    land[armyRow][armyColl] = 'A';
                }
                else
                {
                    land[armyRow][armyColl] = 'X';
                    Console.WriteLine($"The army was defeated at {armyRow};{armyColl}.");
                    PrintLand(land);
                    isEnd = true;
                    return;
                }

            }
            else if (land[armyRow][armyColl]=='M')
            {
                land[mordorRow][mordorColl] = '-';
                Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                PrintLand(land);
                isEnd=true;
                return;
            }
            else
            {
                land[armyRow][armyColl] = 'A';
            }
        }
        static int[] FindArmy(char[][] land)
        {
            int[] armyCoordinates = new int[2];
            for (int r = 0; r < land.Length; r++)
            {
                for (int c = 0; c < land[r].Length ; c++)
                {
                    if (land[r][c]=='A')
                    {
                        armyCoordinates[0] = r;
                        armyCoordinates[1] = c;   
                    }
                }
            }
            return armyCoordinates;
        }
        static int[] FindMordor(char[][] land)
        {
            int[] mordorCoordinates = new int[2];
            for (int r = 0; r < land.GetLength(0); r++)
            {
                for (int c = 0; c < land[r].Length; c++)
                {
                    if (land[r][c] == 'M')
                    {
                        mordorCoordinates[0] = r;
                        mordorCoordinates[1] = c;
                    }
                }
            }
            return mordorCoordinates;   
        }
        static bool IsValid(char[][] land,int row,int col)
        {
            bool isValid = false;
            if (row>=0 && row<land.Length && col>=0 && col < land[row].Length)
            {
                isValid = true;
            }
            return isValid;
        }
    }
}

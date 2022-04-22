using System;
using System.Collections.Generic;

namespace P04._Matching_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
     
            string input = Console.ReadLine();
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i]=='(')
                {
                    stack.Push(i);
                }
                else if (input[i]==')')
                {
                    int startIndex=stack.Pop();
                    int endIndex = i;  
                    string substring=input.Substring(startIndex, endIndex - startIndex+1);
                    Console.WriteLine(substring);
                }
            }

        }
    }
}

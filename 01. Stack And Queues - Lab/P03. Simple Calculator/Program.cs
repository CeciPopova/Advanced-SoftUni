using System;
using System.Collections.Generic;
using System.Linq;

namespace P03._Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
           string[] input = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).ToArray();
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < input.Length; i++)
            {
                int num = 0;
                if (input[i]=="-")
                {
                    num = -int.Parse(input[i + 1]);
                    i++;
                }
                else if(input[i]=="+")  
                {
                    num = int.Parse(input[i + 1]);
                    i++;
                }
                else
                {
                    num = int.Parse(input[i]);
                }
                stack.Push(num);
            }
            Console.WriteLine(stack.Sum());    
        }
    }
}

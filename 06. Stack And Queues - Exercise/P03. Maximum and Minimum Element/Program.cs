using System;
using System.Collections.Generic;
using System.Linq;

namespace P03._Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
          int queries = int.Parse(Console.ReadLine());
            for (int i = 0; i < queries; i++)
            {
                int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                if (input[0] == 1)
                {
                    stack.Push(input[1]);
                }
                else if (input[0] == 2)
                {
                    if (stack.Count>0)
                    {
                        stack.Pop();
                    }
                }
                else if (input[0] == 3)
                {
                    if (stack.Count>0)
                    {
                        Console.WriteLine(stack.Max());
                    }
                }
                else if (input[0] == 4)
                {
                    if (stack.Count>0)
                    {
                        Console.WriteLine(stack.Min());
                    }
                }
            }
            if (stack.Count>0)
            {
                Console.WriteLine(string.Join(", ",stack));
            }
        }
    }
}

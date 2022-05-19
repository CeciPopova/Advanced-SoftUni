using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int numToPush = numbers[0];
            int numToPop = numbers[1];
            int elementToFind = numbers[2];

            int[] elements = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            if (elements.Length >= numToPush)
            {
                for (int i = 0; i < elements.Length; i++)
                {
                    int elementToPush = elements[i];
                    stack.Push(elementToPush);
                }
            }
            if (stack.Count >= numToPop)
            {
                for (int i = 0; i < numToPop; i++)
                {
                    stack.Pop();
                }
            }


            if (stack.Contains(elementToFind))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count > 0)
            {
                int minElement = stack.Min();
                Console.WriteLine(minElement);
            }
            else
            {
                Console.WriteLine("0");
            }
            
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace P05._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] clothesValues = Console.ReadLine()
                  .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                  .Select(int.Parse).ToArray();
            int capacity = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>(clothesValues);
            int racks = 0;

            while (stack.Count != 0)
            {
                int sumOfClotesValue = 0;
                racks++;
                while (sumOfClotesValue < capacity)
                {
                    if (stack.Count > 0)
                    {
                        int currValue = stack.Peek();
                        sumOfClotesValue += currValue;
                        if (sumOfClotesValue <= capacity)
                        {
                            stack.Pop();
                        }
                    }
                    else
                    {
                        break;
                    }
                }

            }
            Console.WriteLine(racks);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace P02._Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();
            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int elementsToEnqueue = input[0];
            int numberToDequeue = input[1]; 
            int elementToFind = input[2];

            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            for (int i = 0; i < elementsToEnqueue; i++)
            {

                queue.Enqueue(numbers[i]);
                
            }
            for (int i = 0; i < numberToDequeue; i++)
            {
                queue.Dequeue();
            }
            if (queue.Contains(elementToFind))
            {
                Console.WriteLine("true");
            }
            else if(queue.Count>0)
            {
                Console.WriteLine(queue.Min());
            }
            else
            {
                Console.WriteLine("0");
            }

        }
    }
}

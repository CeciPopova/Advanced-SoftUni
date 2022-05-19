using System;
using System.Collections.Generic;
using System.Linq;

namespace P04._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int foodQuantity = int.Parse(Console.ReadLine());
           int[] orerQuantity = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            Queue<int> orders = new Queue<int>(orerQuantity);
            int biggestOrder = orders.Max();
            Console.WriteLine(biggestOrder);
            while (orders.Count!=0)
            {
                int currOrder = orders.Peek();
                if (foodQuantity>=currOrder)
                {
                    orders.Dequeue();
                    foodQuantity -= currOrder;
                }
                else
                {
                    Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
                    break;
                }
            }
            if (orders.Count==0)
            {
                Console.WriteLine("Orders complete");
            }
           

        }
    }
}

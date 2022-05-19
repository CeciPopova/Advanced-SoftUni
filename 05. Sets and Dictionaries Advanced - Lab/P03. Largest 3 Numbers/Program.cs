using System;
using System.Collections.Generic;
using System.Linq;

namespace P03._Largest_3_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> sorted = numbers.OrderByDescending(x=>x).ToList();

            for (int i = 0; i < 3; i++)
            {
                if (i<sorted.Count)
                {
                    Console.Write($"{sorted[i]} ");
                }
               
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace P02._Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int[] input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse).ToArray();
            int firstSetLenght = input[0];
            int secondSetLenght = input[1];
            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>(); 
            List<int> list = new List<int>();

            for (int i = 0; i < firstSetLenght; i++)
            {
                int firstSetValues = int.Parse(Console.ReadLine());
                firstSet.Add(firstSetValues);
            }
            for (int i = 0; i < secondSetLenght; i++)
            {
                int secondSetValues = int.Parse(Console.ReadLine());    
                secondSet.Add(secondSetValues); 
            }
            if (firstSet.Count>secondSet.Count)
            {
                foreach (var item in firstSet)
                {
                    if (secondSet.Contains(item))
                    {
                        list.Add(item);
                    }
                }
            }
            else
            {
                foreach (var item in secondSet)
                {
                    if (firstSet.Contains(item))
                    {
                        list.Add(item);
                    }
                }
            }
            Console.WriteLine(String.Join(" ", list));
        }
    }
}

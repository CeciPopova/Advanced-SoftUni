using System;
using System.Collections.Generic;
using System.Linq;

namespace P08._List_Of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int n =int.Parse(Console.ReadLine());
            List<int> dividers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            List<int> numbers = new List<int>();  
            for (int i = 1; i <= n; i++)
            {
                numbers.Add(i);
            }
            List<int> printNumbers = new List<int>();
            foreach (var num in numbers)
            {
                bool isDivisible = true;    
                foreach (var div in dividers)
                {
                    Predicate<int> divisible = num => num%div==0;
                    if (!divisible(num))
                    {
                        isDivisible = false;    
                        break;
                    }
                    
                }
                if (isDivisible)
                {
                    printNumbers.Add(num);  
                }
            }
            Console.WriteLine(String.Join(" ", printNumbers));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace P01._Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Dictionary<string,int> numbers2 = new Dictionary<string,int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers2.ContainsKey(numbers[i]))
                {
                    numbers2[numbers[i]]++;
                }
                else
                {
                    numbers2.Add(numbers[i], 1);
                }
                
            }
            foreach (var number in numbers2)
            {
                Console.WriteLine($"{number.Key} - {number.Value} times");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace P04._Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] bounds = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int start = bounds[0];
            int end = bounds[1];  
          
            List<int> list = new List<int>();
            Predicate<int> predicate =null;
            for (int i = start ; i <= end; i++)
            {
                list.Add(i);
               
            }
            string command = Console.ReadLine();
            if (command == "odd")
            {
                predicate = n => n % 2 != 0;
            }
            else if (command == "even")
            {
                predicate = n => n % 2 == 0;
            }
          
            Console.WriteLine(string.Join(" ",list.FindAll(predicate)));  

        }
    }
}

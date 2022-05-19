using System;
using System.Linq;

namespace P01._Sort_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();   
            int[] sortedEvenNumbers= numbers.OrderBy(x=>x).Where(x=>x%2==0).ToArray();    
            Console.WriteLine(String.Join(", ",sortedEvenNumbers));   
        }
    }
}

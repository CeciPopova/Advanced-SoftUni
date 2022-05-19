using System;
using System.Linq;

namespace P02._Sum_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> parser= x=>int.Parse(x);
            int[] numbers = Console.ReadLine()
                 .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(parser).ToArray();
            int sum = numbers.Sum();
            Console.WriteLine(numbers.Count());
            Console.WriteLine(sum);
           
        }
    }
}

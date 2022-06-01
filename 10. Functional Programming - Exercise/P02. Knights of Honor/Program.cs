using System;
using System.Linq;

namespace P02._Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();

            Action<string> printStrings = x => Console.WriteLine("Sir" + " " +x);
            for (int i = 0; i < input.Length; i++)
            {
                printStrings(input[i]);
            }
        }
    }
}

using System;
using System.Linq;

namespace P01._Action_Print
{
    internal class Program
    {
        static void Main(string[] args)
        {
           string[] input = Console.ReadLine().Split(' ').ToArray();
            Action<string> printStrings = x => Console.WriteLine(x);

            for (int i = 0; i < input.Length; i++)
            {
                printStrings(input[i]);
            }
        }
    }
}

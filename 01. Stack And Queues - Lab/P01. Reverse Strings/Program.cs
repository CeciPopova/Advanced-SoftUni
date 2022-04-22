using System;
using System.Collections.Generic;

namespace P01._Reverse_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
           string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>(input);

            foreach (var item in stack)
            {
                Console.Write(item);
            }

        }
    }
}

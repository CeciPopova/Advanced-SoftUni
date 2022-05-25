using System;
using System.Collections.Generic;
using System.Linq;

namespace P05._Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
           
            Dictionary<char, int> symbols = new Dictionary<char, int>();
            for (int i = 0; i < input.Length; i++)
            {
                char currChar = input[i];
                if (!symbols.ContainsKey(currChar))
                {
                   symbols.Add(currChar, 1);

                }
                else
                {
                        symbols[currChar]++;
                }
            }
           
            foreach (var simbol in symbols.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{simbol.Key}: {simbol.Value} time/s");
            }
        }
    }
}

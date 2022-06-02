using System;
using System.Collections.Generic;
using System.Linq;

namespace P07._Predicate_For_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int n = int.Parse(Console.ReadLine());   
            List<string> names = Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            Func<string,bool> predicate = name => name.Length<=n;
            names = names.Where(predicate).ToList();
            Console.WriteLine(string.Join(Environment.NewLine,names));
        }
    }
}

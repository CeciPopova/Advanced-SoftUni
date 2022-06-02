using System;
using System.Collections.Generic;
using System.Linq;

namespace P05._Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
           List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            Func<List<int>, List<int>> modifyNumbers = null;
            Action<List<int>> printList = null; 
            string command = Console.ReadLine();
            while (command!="end")
            {
                if (command=="add")
                {
                    modifyNumbers= list=>list.Select(n=>n+1).ToList();
                   numbers= modifyNumbers(numbers);
                }
                else if (command=="multiply")
                {
                    modifyNumbers=list=>list.Select(n=>n*2).ToList();   
                    numbers = modifyNumbers(numbers);
                }
                else if (command=="subtract")
                {
                    modifyNumbers = list=>list.Select(n=>n-1).ToList();
                    numbers = modifyNumbers(numbers);   
                }
                else if (command=="print")
                {
                    printList = list =>Console.WriteLine(string.Join(" ",numbers));
                    printList(numbers);
                }


                command = Console.ReadLine();

            }
        }
    }
}

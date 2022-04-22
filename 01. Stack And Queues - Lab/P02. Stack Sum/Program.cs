using System;
using System.Collections.Generic;
using System.Linq;

namespace P02._Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();   
            Stack<int> stack = new Stack<int>(numbers);
            string command = Console.ReadLine().ToLower();
            while (command!="end")
            {
                string[] commandArgs=command.Split(' ');    
                string action = commandArgs[0];
                if (action=="add")
                {
                    int firstNum = int.Parse(commandArgs[1]);
                    int secondNum = int.Parse(commandArgs[2]);  
                    stack.Push(firstNum);   
                    stack.Push(secondNum);
                }
                else if (action=="remove")
                {
                    int num = int.Parse(commandArgs[1]);
                    if (stack.Count>=num)
                    {
                        for (int i = 0; i < num; i++)
                        {
                            stack.Pop();
                        }
                    }
                }


                command = Console.ReadLine().ToLower();
            }
          
            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}

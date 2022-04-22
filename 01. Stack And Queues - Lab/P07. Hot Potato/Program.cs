using System;
using System.Collections.Generic;
using System.Linq;

namespace P07._Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
           string[] kids=Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            int n = int.Parse(Console.ReadLine());
            int count = 0;
            Queue<string> queue = new Queue<string>(kids);
            while (queue.Count>1)
            {
                count++;
               string currKid = queue.Dequeue();
                if (count!=n)
                {
                    queue.Enqueue(currKid);
                }
                else
                {
                    Console.WriteLine($"Removed {currKid}");
                    count = 0;
                }
            }
            Console.WriteLine($"Last is {queue.Peek()}");
        }
    }
}

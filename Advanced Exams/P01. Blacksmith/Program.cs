using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace P01._Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();    
            int[] input2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Queue<int> steel = new Queue<int>(input1);
            Stack<int> carbon = new Stack<int>(input2);
            Dictionary<string, int> swords = new Dictionary<string, int>
            {
                {"Gladius",0 },
                {"Shamshir",0 },
                {"Katana",0 },
                {"Sabre",0 },
                {"Broadsword",0 }
            };
           
            while (steel.Any() && carbon.Any())
            {
                int mix=steel.Peek()+carbon.Peek();
                int currCarb= carbon.Pop();
                if (mix==70)
                {
                    swords["Gladius"]++;
                }
                else if (mix==80)
                {
                    swords["Shamshir"]++;
                }
                else if (mix==90)
                {
                    swords["Katana"]++;
                }
                else if (mix==110)
                {
                    swords["Sabre"]++;
                }
                else if (mix==150)
                {
                    swords["Broadsword"]++;
                }
                else
                {
                    currCarb += 5;
                    carbon.Push(currCarb);
                }
                steel.Dequeue();
               
            }
            int count = swords.Values.Sum();
            if (count>0)
            {
                Console.WriteLine($"You have forged {count} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }
            if (steel.Any())
            {
                Console.WriteLine($"Steel left: {string.Join(", ",steel)}");
            }
            else
            {
                Console.WriteLine("Steel left: none");
            }
            if (carbon.Any())
            {
                Console.WriteLine($"Carbon left: {string.Join(", ",carbon)}");
            }
            else
            {
                Console.WriteLine("Carbon left: none");
            }
            foreach (var item in swords.OrderBy(x=>x.Key))
            {
                if (item.Value>0)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace P01._Lootbox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] input2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Queue<int> firstLootbox = new Queue<int>(input1);
            Stack<int> secondLootbox = new Stack<int>(input2);
            List<int> claimedItems = new List<int>();
            while (firstLootbox.Any()&&secondLootbox.Any())
            {
                int item = secondLootbox.Peek();
                int sum = firstLootbox.Peek() + secondLootbox.Pop();
                if (sum%2==0)
                {
                    claimedItems.Add(sum);
                    firstLootbox.Dequeue();
                }
                else
                {
                    firstLootbox.Enqueue(item); 
                }
            }
            if (firstLootbox.Any())
            {
                Console.WriteLine("Second lootbox is empty");
            }
            else
            {
                Console.WriteLine("First lootbox is empty");
            }
            int totalSum = claimedItems.Sum();
            if (totalSum>=100)
            {
                Console.WriteLine($"Your loot was epic! Value: {totalSum}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {totalSum}");
            }
        }
    }
}

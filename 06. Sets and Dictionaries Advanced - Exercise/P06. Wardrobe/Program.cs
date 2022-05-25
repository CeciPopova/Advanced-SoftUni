using System;
using System.Collections.Generic;
using System.Linq;

namespace P06._Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < n; i++)
            {
                string[] clothes = Console.ReadLine()
               .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
               .ToArray();
                string color = clothes[0];
                string items = clothes[1];
                string[] itemsArgs = items.Split(",", StringSplitOptions.RemoveEmptyEntries);
                Dictionary<string, int> wardrobeArgs = new Dictionary<string, int>();
                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, wardrobeArgs);

                }
                for (int j = 0; j < itemsArgs.Length; j++)
                {
                    string currItem = itemsArgs[j];
                    if (!wardrobe[color].ContainsKey(currItem))
                    {
                        wardrobe[color].Add(currItem, 1);
                    }
                    else
                    {
                        wardrobe[color][currItem]++;
                    }
                }
            }
            string[] clothingToLookFor = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string colourToLookFor = clothingToLookFor[0];
            string currClothing = clothingToLookFor[1];

            foreach (var item in wardrobe)
            {
                Console.WriteLine($"{item.Key} clothes:");
                foreach (var thing in item.Value)
                {
                   
                    if (item.Key == colourToLookFor && thing.Key == currClothing)
                    {
                        Console.WriteLine($"* {thing.Key} - {thing.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {thing.Key} - {thing.Value}");
                    }

                }

            }
        }
    }
}

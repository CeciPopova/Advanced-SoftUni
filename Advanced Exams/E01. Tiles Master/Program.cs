using System;
using System.Collections.Generic;
using System.Linq;

namespace E01._Tiles_Master
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[] input2 = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Queue<int> greyTiles = new Queue<int>(input2);
            Stack<int> whiteTiles = new Stack<int>(input1);
            Dictionary<string, int> tiles = new Dictionary<string, int>
            {
                {"Sink", 0 },
                {"Oven", 0 },
                {"Countertop", 0 },
                {"Wall", 0 },
                {"Floor", 0 }
            };
            while (greyTiles.Any() && whiteTiles.Any())
            {
                if (greyTiles.Peek()==whiteTiles.Peek())
                {
                    if (greyTiles.Peek()+whiteTiles.Peek()==40)
                    {
                        tiles["Sink"]++;
                    }
                    else if (greyTiles.Peek() + whiteTiles.Peek() == 50)
                    {
                        tiles["Oven"]++;
                    }
                    else if (greyTiles.Peek() + whiteTiles.Peek() == 60)
                    {
                        tiles["Countertop"]++;
                    }
                    else if (greyTiles.Peek() + whiteTiles.Peek() == 70)
                    {
                        tiles["Wall"]++;
                    }
                    else
                    {
                        tiles["Floor"]++;
                    }
                    greyTiles.Dequeue();
                    whiteTiles.Pop();
                }
                else
                {
                    int currWhiteTile=whiteTiles.Pop()/2;
                    whiteTiles.Push(currWhiteTile);
                    int currGreyTile=greyTiles.Dequeue();
                    greyTiles.Enqueue(currGreyTile);

                }

            }
            if (whiteTiles.Any())
            {
                Console.WriteLine($"White tiles left: {string.Join(", ",whiteTiles)}");
            }
            else
            {
                Console.WriteLine("White tiles left: none");
            }
            if (greyTiles.Any())
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ",greyTiles)}");
            }
            else
            {
                Console.WriteLine("Grey tiles left: none");
            }
            foreach (var item in tiles.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                if (item.Value>0)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }

        }
    }
}

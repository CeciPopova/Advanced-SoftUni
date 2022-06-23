using System;
using System.Collections.Generic;
using System.Linq;

namespace P01._The_Fight_for_Gondor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfWaves = int.Parse(Console.ReadLine());
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            
            Queue<int> aragonsPlates = new Queue<int>(input);
            Stack<int> orgs = new Stack<int>();
            for (int i = 1; i <= numOfWaves; i++)
            {
                int[] waveOfOrcs = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
               
                if (aragonsPlates.Count <= 0)
                {
                    break;
                }
                orgs = new Stack<int>(waveOfOrcs);
                if (i % 3 == 0)
                {

                    int plate = int.Parse(Console.ReadLine());
                    aragonsPlates.Enqueue(plate); 
                }
                while (aragonsPlates.Any() && orgs.Any())
                {
                    if (orgs.Peek() > aragonsPlates.Peek())
                    {
                        int orgValue = orgs.Pop() - aragonsPlates.Dequeue();
                        orgs.Push(orgValue);
                    }
                    else if (orgs.Peek() == aragonsPlates.Peek())
                    {
                        orgs.Pop();
                        aragonsPlates.Dequeue();
                    }
                    else
                    {
                        int currPlate = aragonsPlates.Dequeue() - orgs.Pop();
                        int count = aragonsPlates.Count;
                        aragonsPlates.Enqueue(currPlate);
                        for (int j = 0; j < count; j++)
                        {
                            aragonsPlates.Enqueue(aragonsPlates.Dequeue());
                        }
                        
                    }
                }

            }
            if (orgs.Any())
            {
                Console.WriteLine($"The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", orgs)}");
            }
            else
            {
                Console.WriteLine($"The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", aragonsPlates)}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.Warm_Winter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] input2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Queue<int> scarfs = new Queue<int>(input2);
            Stack<int> hats = new Stack<int>(input1);
            List<int> sets = new List<int>();    
            while (scarfs.Any() && hats.Any())
            {
                if (hats.Peek()>scarfs.Peek())
                {
                    sets.Add(hats.Pop() + scarfs.Dequeue());
                }
                else if (hats.Peek()==scarfs.Peek())
                {
                    scarfs.Dequeue();
                    int currHat=hats.Pop()+1; 
                    hats.Push(currHat);
                }
                else
                {
                    hats.Pop();
                    continue;
                }

            }
            int maxPriceSet = sets.Max();
            Console.WriteLine($"The most expensive set is: {maxPriceSet}");
            Console.WriteLine(String.Join(" ",sets));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace P01._Birthday_Celebration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] input2 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> guests = new Queue<int>(input1);
            Stack<int> plates = new Stack<int>(input2);
            int wastedFood = 0;
            while (guests.Any() && plates.Any())
            {
                int currGuest = guests.Peek();
                int currPlate = plates.Pop();

                if (currGuest - currPlate <= 0)
                {
                    wastedFood += currPlate - currGuest;
                    guests.Dequeue();
                }
                else
                {
                    while (currGuest-currPlate > 0)
                    {
                        if (plates.Any())
                        {
                            currPlate += plates.Pop();
                             
                        }
                        else
                        {
                            break;
                        }
                        
                    }
                    if (currGuest-currPlate<=0)
                    {
                        currGuest-=currPlate;   
                        guests.Dequeue();
                        wastedFood+=Math.Abs(currGuest);
                    }
                  
                }
            }
            if (guests.Any())
            {
                Console.WriteLine($"Guests: {string.Join(" ", guests)}");
            }
            if (plates.Any())
            {
                Console.WriteLine($"Plates: {string.Join(" ", plates)}");
            }
            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}

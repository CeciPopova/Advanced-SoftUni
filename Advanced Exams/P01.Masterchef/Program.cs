using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.Masterchef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] input2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Queue<int> ingredents = new Queue<int>(input1);
            Stack<int> freshness = new Stack<int>(input2);
            Dictionary<string, int> dishes = new Dictionary<string, int>
            {
                {"Dipping sauce", 0 },
                {"Green salad", 0},
                {"Chocolate cake", 0 },
                {"Lobster", 0 }
            };
            while (ingredents.Any() && freshness.Any())
            {
                int ingredentValue = ingredents.Peek();
                if (ingredentValue==0)
                {
                    ingredents.Dequeue();
                    continue;
                }
                int totalFreshnes = ingredents.Dequeue() * freshness.Pop();
                if (totalFreshnes==150)
                {
                    dishes["Dipping sauce"]++;
                }
                else if (totalFreshnes==250)
                {
                    dishes["Green salad"]++;
                }
                else if (totalFreshnes==300)
                {
                    dishes["Chocolate cake"]++;
                }
                else if (totalFreshnes==400)
                {
                    dishes["Lobster"]++;
                }
                else
                {
                    ingredentValue+= 5;
                    ingredents.Enqueue(ingredentValue);
                }
            }
            var currDish = dishes.OrderBy(d => d.Value).FirstOrDefault();
            if (currDish.Value > 0)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");

            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }
            if (ingredents.Any())
            {
                Console.WriteLine($"Ingredients left: {ingredents.Sum()}");
            }
            foreach (var dish in dishes.OrderBy(d=>d.Key))
            {
                if (dish.Value > 0)
                {
                    Console.WriteLine($"# {dish.Key} --> {dish.Value}");
                }
            }
        }
    }
}

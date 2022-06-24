using System;
using System.Collections.Generic;
using System.Linq;

namespace P01._Cooking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[] input2 = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse).ToArray();
            Queue<int> liquids = new Queue<int>(input1);
            Stack<int> ingredients = new Stack<int>(input2);
            Dictionary<string, int> bakes = new Dictionary<string, int>
            {
                {"Bread",0 },
                {"Cake",0 },
                {"Pastry",0 },
                {"Fruit Pie",0 }
            };
            while (liquids.Any() && ingredients.Any())
            {
                if (liquids.Peek()+ingredients.Peek()==25)
                {
                    bakes["Bread"]++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else if (liquids.Peek() + ingredients.Peek() == 50)
                {
                    bakes["Cake"]++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else if (liquids.Peek() + ingredients.Peek() == 75)
                {
                    bakes["Pastry"]++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else if (liquids.Peek() + ingredients.Peek() == 100)
                {
                    bakes["Fruit Pie"]++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else
                {
                    liquids.Dequeue();
                    int currIngredient = ingredients.Pop()+3;
                    ingredients.Push(currIngredient);
                }
            }
            bool isSucceeded = true;
            foreach (var item in bakes)
            {
                if (item.Value==0)
                {
                    isSucceeded = false;
                }
            }
            if (isSucceeded)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
               
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }
            if (liquids.Any())
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }
            if (ingredients.Any())
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ",ingredients)}");
            }
            else
            {
                Console.WriteLine("Ingredients left: none");
            }
            foreach (var item in bakes.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}

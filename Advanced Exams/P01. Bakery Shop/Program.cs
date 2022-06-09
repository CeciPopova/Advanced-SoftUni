using System;
using System.Collections.Generic;
using System.Linq;

namespace P01._Bakery_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] input1 = Console.ReadLine()
                .Split(' ').Select(double.Parse).ToArray();
            double[] input2 = Console.ReadLine()
               .Split(' ').Select(double.Parse).ToArray();
            Queue<double> water = new Queue<double>(input1);
            Stack<double> flour = new Stack<double>(input2);
            Dictionary<string, int> bakes = new Dictionary<string, int>
            {
                {"Croissant",0 },
                {"Muffin",0 },
                {"Baguette",0 },
                {"Bagel",0 }
            };
            while (water.Any() && flour.Any())
            {
                double currWater = water.Peek();
                double currFlour = flour.Peek();
                if (Croissant(currWater, currFlour))
                {
                    bakes["Croissant"]++;
                    water.Dequeue();
                    flour.Pop();
                }
                else if (Muffin(currWater, currFlour))
                {
                    bakes["Muffin"]++;
                    water.Dequeue();
                    flour.Pop();
                }
                else if (Baguette(currWater, currFlour))
                {
                    bakes["Baguette"]++;
                    water.Dequeue();
                    flour.Pop();
                }
                else if (Bagel(currWater, currFlour))
                {
                    bakes["Bagel"]++;
                    water.Dequeue();
                    flour.Pop();
                }
                else
                {
                    double currentWater = water.Dequeue();
                    double currentFlour = flour.Pop();
                    double reducedFlouer = currentFlour - currentWater;
                    bakes["Croissant"]++;
                    flour.Push(reducedFlouer);
                }
            }

            foreach (var bake in bakes.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                if (bake.Value > 0)
                {
                    Console.WriteLine($"{bake.Key}: {bake.Value}");
                }
            }
            if (water.Count>0)
            {
                Console.WriteLine($"Water left: {string.Join(", ",water)}");
            }
            else
            {
                Console.WriteLine("Water left: None");
            }
            if (flour.Count>0)
            {
                Console.WriteLine($"Flour left: {string.Join(", ", flour)}");
            }
            else
            {
                Console.WriteLine("Flour left: None");
            }


        }
        static bool Croissant(double currWater, double currFlour)
        {
            double[] percent = CalculatePercent(currWater, currFlour);
            if (percent[0] == 50 && percent[1] == 50)
            {
                return true;
            }
            return false;
        }
        static bool Muffin(double currWater, double currFlour)
        {
            double[] percent = CalculatePercent(currWater, currFlour);
            if (percent[0] == 40 && percent[1] == 60)
            {
                return true;
            }
            return false;
        }
        static bool Baguette(double currWater, double currFlour)
        {
            double[] percent = CalculatePercent(currWater, currFlour);
            if (percent[0] == 30 && percent[1] == 70)
            {
                return true;
            }
            return false;
        }
        static bool Bagel(double currWater, double currFlour)
        {
            double[] percent = CalculatePercent(currWater, currFlour);
            if (percent[0] == 20 && percent[1] == 80)
            {
                return true;
            }
            return false;
        }
        static double[] CalculatePercent(double currWater, double currFlour)
        {
            double[] mixResult = new double[2];
            double mix = currWater + currFlour;
            mixResult[0] = currWater * 100 / mix;
            mixResult[1] = currFlour * 100 / mix;

            return mixResult;
        }
    }
}

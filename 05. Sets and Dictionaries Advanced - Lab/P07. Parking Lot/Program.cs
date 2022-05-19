using System;
using System.Collections.Generic;
using System.Linq;

namespace P07._Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            HashSet<string> parking = new HashSet<string>();
            while (input!="END")
            {
                string[] inputArgs = input
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();  
                string directions = inputArgs[0];   
                string car = inputArgs[1];
                if (directions=="IN")
                {
                    parking.Add(car);
                }
                else if (directions=="OUT")
                {
                    if (parking.Contains(car))
                    {
                        parking.Remove(car);
                    }
                }

                input = Console.ReadLine(); 
            }
            if (parking.Count>0)
            {
                foreach (var car in parking)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            
        }
    }
}

using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] inputArgs = input.Split(' ');
                string model = inputArgs[0];
                double fuelAmount = double.Parse(inputArgs[1]);
                double fuelConsumption = double.Parse(inputArgs[2]);
                double distance = 0;
                Car car = new Car(model, fuelAmount, fuelConsumption, distance);
                cars.Add(car);
            }
            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] cmndArgs = command.Split(' ');
              
                string model = cmndArgs[1];
                double amountOfKm = double.Parse(cmndArgs[2]);

               Car currCar = cars.Find(x => x.Model == model);
                currCar.Drive(amountOfKm);  

                command = Console.ReadLine();
            }
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TraveledDistance}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<List<double>> listOfTirePressures = new List<List<double>>();
            List<List<Tire>> tires = new List<List<Tire>>();
            string input = Console.ReadLine();
            while (input != "No more tires")
            {
                string[] inputArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                List<Tire> carTires = new List<Tire>();
                List<double> tirePressures = new List<double>();
                int year = 0;
                double pressure = 0;

                for (int i = 0; i < inputArgs.Length; i+=2)
                {
                   year = int.Parse(inputArgs[i]);
                    pressure = double.Parse(inputArgs[i+1]);   
                    Tire tire = new Tire(year, pressure);
                    carTires.Add(tire);
                    tirePressures.Add(pressure);
                }
                listOfTirePressures.Add(tirePressures); 
                tires.Add(carTires);
                input = Console.ReadLine();
            }


            List<Engine> engines = new List<Engine>();
            string secondInput = Console.ReadLine();
            while (secondInput != "Engines done")
            {
                string[] comndArgs = secondInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int horsePower = int.Parse(comndArgs[0]);
                double cubicCapacity = double.Parse(comndArgs[1]);
                engines.Add(new Engine(horsePower, cubicCapacity));
                secondInput = Console.ReadLine();
            }
            List<Car> cars = new List<Car>();
            string thirdInput = Console.ReadLine();
            double sumPressure = 0;
           
            while (thirdInput != "Show special")
            {
                string[] finalStepArgs = thirdInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string make = finalStepArgs[0];
                string model = finalStepArgs[1];
                int year = int.Parse(finalStepArgs[2]);
                double fuelQuantity = double.Parse(finalStepArgs[3]);
                double fuelConsumption = double.Parse(finalStepArgs[4]);
                int engineIndex = int.Parse(finalStepArgs[5]);
                int tireIndex = int.Parse(finalStepArgs[6]);

                List<Tire> currTireList = new List<Tire>();
                currTireList = tires[tireIndex];
                sumPressure = listOfTirePressures[tireIndex].Sum();

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], currTireList,sumPressure);
                cars.Add(car);
                thirdInput = Console.ReadLine();
               
            }

            foreach (var car in cars)
            {

                if (car.Year >= 2017 && car.Engine.HorsePower > 330&& car.SumPressure>9 && car.SumPressure<10 ) 
                {
                    car.Drive(0.20);

                    Console.WriteLine($"Make: {car.Make}");
                    Console.WriteLine($"Model: {car.Model}");
                    Console.WriteLine($"Year: {car.Year}");
                    Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");
                    Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
                }
            }
        }
    }
}

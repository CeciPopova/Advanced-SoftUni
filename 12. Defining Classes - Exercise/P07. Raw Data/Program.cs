using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ');
                string model = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                Engine engine = new Engine(engineSpeed, enginePower);

                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];
                Cargo cargo = new Cargo(cargoType, cargoWeight);

                List<Tire> tires = new List<Tire>();
                double tire1Pressure = double.Parse(input[5]);
                int tire1Age = int.Parse(input[6]);
                Tire tire1 = new Tire(tire1Age, tire1Pressure);
                tires.Add(tire1);

                double tire2Pressure = double.Parse(input[7]);
                int tire2Age = int.Parse(input[8]);
                Tire tire2 = new Tire(tire2Age, tire2Pressure);
                tires.Add(tire2);

                double tire3Pressure = double.Parse(input[9]);
                int tire3Age = int.Parse(input[10]);
                Tire tire3 = new Tire(tire3Age, tire3Pressure);
                tires.Add(tire3);

                double tire4Pressure = double.Parse(input[11]);
                int tire4Age = int.Parse(input[12]);
                Tire tire4 = new Tire(tire4Age, tire4Pressure);
                tires.Add(tire4);

                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }
            string command = Console.ReadLine();
            var currCars = new List<Car>();

            bool isPressure = false;
            foreach (var car in cars)
            {
                if (command=="fragile")
                {
                    if (car.Cargo.Type == command)
                    {
                        foreach (var tire in car.Tires)
                        {
                            if (tire.Pressure < 1)
                            {
                                isPressure = true;
                            }
                        }
                        if (isPressure)
                        {
                            Console.WriteLine(car.Model);
                        }
                    }
                }
                else if (command == "flammable")
                {

                    if (car.Cargo.Type == command)
                    {
                        if (car.Engine.Power>250)
                        {
                            Console.WriteLine(car.Model);
                        }
                    }
                }

            }
        }
    }
}

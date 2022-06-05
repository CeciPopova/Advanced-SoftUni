using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] engineData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = engineData[0];
                int power = int.Parse(engineData[1]);

                Engine engine = new Engine(model, power);
                engines.Add(engine);

                if (engineData.Length == 3)
                {
                    bool isDisplasement = int.TryParse(engineData[2], out int displasement);

                    if (isDisplasement)
                    {
                        engine.Displacement = displasement;
                    }
                    else
                    {
                        engine.Efficiency = engineData[2];
                    }

                }
                else if (engineData.Length == 4)
                {
                    engine.Displacement = int.Parse(engineData[2]);
                    engine.Efficiency = engineData[3];
                }
            }
            int m = int.Parse(Console.ReadLine());
            for (int i = 0; i < m; i++)
            {
                string[] carData = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);

                string model = carData[0];
                string engineModel = carData[1];
                Engine carEngine = new Engine(engineModel);
                foreach (var engine in engines)
                {
                    if (engine.Model == engineModel)
                    {
                        carEngine = engine;
                    }
                }

                Car car = new Car(model, carEngine);
                cars.Add(car);
                if (carData.Length==3)
                {
                    bool isWeight = int.TryParse(carData[2], out int weight);
                    if (isWeight)
                    {
                        car.Weight = weight;
                    }
                    else
                    {
                        car.Color=carData[2];   
                    }
                }
                else if (carData.Length==4)
                {
                    car.Weight=int.Parse(carData[2]);
                    car.Color=carData[3];   

                }

            }
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($" {car.Engine.Model}:");
                Console.WriteLine($"   Power: {car.Engine.Power}");
                if (car.Engine.Displacement > 0)
                {
                    Console.WriteLine($"   Displacement: {car.Engine.Displacement}   ");
                }
                else
                {
                    Console.WriteLine($"   Displacement: n/a");
                }
                if (car.Engine.Efficiency != " ")
                {
                    Console.WriteLine($"   Efficiency: {car.Engine.Efficiency}");
                }
                else
                {
                    Console.WriteLine($"   Efficiency: n/a");
                }
                if (car.Weight > 0)
                {
                    Console.WriteLine($" Weight: {car.Weight}");
                }
                else
                {
                    Console.WriteLine($" Weight: n/a");
                }
                if (car.Color != " ")
                {
                    Console.WriteLine($" Color: {car.Color}");
                }
                else
                {
                    Console.WriteLine($" Color: n/a");
                }

            }

        }
    }
}

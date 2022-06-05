using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TraveledDistance { get; set; }
        public Car(string model, double fuelAmount, double fuelConsumption, double distance)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumption;
            this.TraveledDistance = distance;

        }
        public void Drive(double amountOfKm)
        {
            double neededFuel = amountOfKm * FuelConsumptionPerKilometer;
            if (FuelAmount>=neededFuel)
            {
                FuelAmount -= neededFuel;
                TraveledDistance += amountOfKm;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}

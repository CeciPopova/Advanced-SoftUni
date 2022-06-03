using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        private string make;

        public string Make
        {
            get { return make; }
            set { make = value; }
        }
        private string model;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        private int year;

        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        private double fuelQuantity;

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set { fuelQuantity = value; }
        }
        private double fuelConsumption;

        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }

        private Engine engine;

        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }
        private List<Tire> tires;

        public List<Tire> Tires
        {
            get { return tires; }
            set { tires = value; }
        }
        private double sumPressure;

        public double SumPressure
        {
            get { return sumPressure; }
            set { sumPressure = value; }
        }



        public Car()
        {
            Make = "VW";
            Model = "Golf";
            Year = 2025;
            FuelQuantity = 200;
            FuelConsumption = 10;
        }
        public Car(string make, string model, int year)
            :this()
        {
            this.Make = make;
            this.Model = model; 
            this.Year = year;   

        }
        public Car(string make, string model, int year, double fuelQuantity,double fuelConsumption)
            :this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption; 
        }
        public Car(string make,string model, int year,double fuelQuantity, double fuelConsumption,Engine engine,List<Tire> tires) :this(make, model, year, fuelQuantity,fuelConsumption)
        {
            this.Engine = engine;  
            this.Tires = tires;

        }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, List<Tire> tires,double sumPressure):this(make, model,year, fuelQuantity, fuelConsumption, engine, tires)
        {
            this.SumPressure = sumPressure;
        }
        public void Drive(double distance)
        {
            var result = fuelQuantity - distance * fuelConsumption ;
            if (result<0)
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
            else
            {
                    fuelQuantity = result;  
            }
           
        }

        public override string ToString()
        {
            return $"Make: {this.Make}\nModel: {this.Model}\nYear: {this.Year}\nFuel: {this.FuelQuantity:f2}L";
        }

    }
}

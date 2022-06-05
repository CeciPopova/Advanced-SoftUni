using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }
        public Car(string model,Engine engine)
        {
            Model = model;
            Engine = engine;
            Weight = 0;
            Color = " ";

        }
        public Car(string model,Engine engine,int weight,string color) :this(model,engine)
        {
            this.Weight = weight;   
            this.Color = color; 
        }
    }
}

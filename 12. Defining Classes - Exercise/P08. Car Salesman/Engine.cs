using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Engine
    {
        public string Model { get; set; }
        public int Power { get; set; }
        public int Displacement { get; set; }
        public string Efficiency { get; set; }

        public Engine(string model)
        {
            this.Model = model; 
        }
        public Engine(string model,int power)
        {
            this.Model = model; 
            this.Power = power;
            Displacement = 0;
            Efficiency = " ";
        }
        public Engine(string model,int power,int displacement,string efficiency) :this(model,power)
        {
            this.Efficiency = efficiency;
            this.Displacement = displacement;   
        }
    }
}

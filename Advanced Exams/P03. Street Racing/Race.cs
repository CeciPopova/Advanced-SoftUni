using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        public List<Car> Participants { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            this.Participants = new List<Car>();
            this.Name = name;
            this.Type = type;
            this.Laps = laps;
            this.Capacity = capacity;
            this.MaxHorsePower = maxHorsePower;
        }
        public int Count { get { return Participants.Count; } }
        public void Add(Car car)
        {
            if (!Participants.Contains(car) && Capacity > Participants.Count && car.HorsePower <= MaxHorsePower)
            {
                Participants.Add(car);
            }
        }
        public bool Remove(string licensePlate)
        {
            var car = Participants.Find(x => x.LicensePlate == licensePlate);
            if (car == null)
            {
                return false;
            }
            else
            {
                Participants.Remove(car);
                return true;
            }
        }
        public Car FindParticipant(string licensePlate)
        {
            var car = Participants.Find(x => x.LicensePlate == licensePlate);
            if (car == null)
            {
                return null;
            }
            else
            {
                return car;
            }
        }
        public Car GetMostPowerfulCar()
        {
            if (Participants.Count > 0)
            {
                var participants = Participants.OrderByDescending(x => x.HorsePower);
                return participants.FirstOrDefault();
            }
            else
            {
                return null;
            }
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");
            foreach (var car in Participants)
            {
                sb.AppendLine(car.ToString());
            }
            return sb.ToString();
        }
    }
}

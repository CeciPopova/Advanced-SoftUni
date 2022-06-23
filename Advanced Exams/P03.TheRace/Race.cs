using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        public List<Racer> Data { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public Race(string name, int capacity)
        {
            Data = new List<Racer>();
            Name = name;
            Capacity = capacity;
        }
        private List<Racer> data;
        public int Count { get { return Data.Count; } }
        public void Add(Racer racer)
        {
            if (Data.Count < Capacity)
            {
                Data.Add(racer);
            }
        }
        public bool Remove(string name)
        {
            var racer = Data.Find(x => x.Name == name);
            if (racer == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public Racer GetOldestRacer()
        {
            int biggestAge = data.Select(r => r.Age).Max();
            return data.Find(x => x.Age == biggestAge);
        }
        public Racer GetRacer(string name)
        {
            var racer = Data.Find(x => x.Name == name);
            return racer;
        }
        public Racer GetFastestRacer()
        {
            return Data.OrderByDescending(x => x.Car.Speed).FirstOrDefault();
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Racers participating at {Name}:");
            foreach (var racer in Data)
            {
                sb.AppendLine(racer.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}

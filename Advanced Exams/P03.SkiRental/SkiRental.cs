using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        public List<Ski> Data { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public SkiRental(string name, int capacity)
        {
            Data = new List<Ski>(); ;
            Name = name;
            Capacity = capacity;
        }
        private List<Ski> data;
        public int Count { get { return Data.Count; } }
        public void Add(Ski ski)
        {
            if (Data.Count < Capacity)
            {
                Data.Add(ski);
            }
        }
        public bool Remove(string manufacturer,string model)
        {
            var ski = Data.Find(x=>x.Manufacturer==manufacturer && x.Model==model);
            if (ski==null)
            {
                return false;
            }
            else
            {
                Data.Remove(ski);
                return true;
            }
        }
        public Ski GetNewestSki()
        {
            var ski = Data.OrderByDescending(x=>x.Year).FirstOrDefault();
            if (ski == null)
            {
                return null;
            }
            else
            {
                return ski;
            }
        }
        public Ski GetSki(string manufacturer, string model)
        {
            var ski = Data.Find(x=>x.Manufacturer==manufacturer && x.Model==model);
            if (ski==null)
            {
                return null;
            }
            else
            {
                return ski; 
            }
        }
        public string GetStatistics()
        {
            StringBuilder sbb = new StringBuilder();
            sbb.AppendLine($"The skis stored in {Name}:");
            foreach (var item in Data)
            {
                sbb.AppendLine(item.ToString());
            }
            return sbb.ToString();  
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        public List<Fish> fish { get; set; }
        public string Material { get; set; }
        public int Capacity { get; set; }
        public Net(string material, int capacity)
        {
            fish = new List<Fish>();
            Material = material;
            Capacity = capacity;
        }
        public int Count => this.fish.Count;
        public IReadOnlyCollection<Fish> Fish => (IReadOnlyCollection<Fish>)this.fish;
        public string AddFish(Fish fish)
        {
            if (string.IsNullOrWhiteSpace(fish.FishType) || fish.Length <= 0 || fish.Weight <= 0)
            {
                return $"Invalid fish.";

            }
            if (Fish.Count >= Capacity)
            {
                return "Fishing net is full.";
            }

            this.fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";

        }
        public bool ReleaseFish(double weight)
        {
            var fish=this.fish.FirstOrDefault(fish => fish.Weight <= weight);
            if (fish!=null)
            {
                this.fish.Remove(fish);
                return true;
            }
            else
            {
                return false;
            }
        }
        public Fish GetFish(string fishType)
        {
            Fish fish=this.fish.FirstOrDefault(f=>f.FishType==fishType);
            return fish;
        }
        public Fish GetBiggestFish()
        {
            var biggestFish = this.fish.Max(f=>f.Length);
            Fish fish = this.fish.FirstOrDefault(f => f.Length == biggestFish);
            return fish;
           
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Into the {this.Material}:");

            foreach (var item in Fish.OrderByDescending(x => x.Length))
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}

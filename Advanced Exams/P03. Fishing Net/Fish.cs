namespace FishingNet
{
    public class Fish
    {
        private string fishType;

        public string FishType
        {
            get { return fishType; }
            set { fishType = value; }
        }
        private double length;

        public double Length
        {
            get { return length; }
            set { length = value; }
        }
        private double weight;

        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        public Fish(string fishType,  double length, double weight)
        {
            FishType = fishType;
            Length = length;
            Weight = weight;    
        }
        public override string ToString()
        {
            string result = $"There is a {fishType}, {length} cm. long, and {weight} gr. in weight.";


            return result.ToString();
        }
    }
}


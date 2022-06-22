using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        public List<Ingredient> Ingredients { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Ingredients = new List<Ingredient>();
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
        }
        public void Add(Ingredient ingredient)
        {
            if (Ingredients.Count < Capacity)
            {
                Ingredients.Add(ingredient);
            }
        }
        public bool Remove(string name)
        {
            var ingredient = Ingredients.Find(x => x.Name == name);
            if (ingredient == null)
            {
                return false;
            }
            else
            {
                Ingredients.Remove(ingredient);
                return true;
            }
        }
        public Ingredient FindIngredient(string name)
        {
            var ingrediant = Ingredients.Find(x => x.Name == name);
            if (ingrediant == null)
            {
                return null;
            }
            else
            {
                return ingrediant;
            }
        }
        public Ingredient GetMostAlcoholicIngredient()
        {
            var ingrediant = Ingredients.OrderByDescending(x => x.Alcohol).First();
            return ingrediant;
        }
        public int CurrentAlcoholLevel { get { return Ingredients.Sum(x => x.Alcohol); } }

        public string Report()
        {
            StringBuilder sbb = new StringBuilder();
            sbb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");
            foreach (var item in Ingredients)
            {
                sbb.AppendLine(item.ToString());
            }
            return sbb.ToString();
        }
    }
}

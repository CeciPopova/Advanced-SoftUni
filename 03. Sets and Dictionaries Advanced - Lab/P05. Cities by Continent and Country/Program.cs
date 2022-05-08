using System;
using System.Collections.Generic;
using System.Linq;

namespace P05._Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> countries = new Dictionary<string, Dictionary<string, List<string>>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ').ToArray();
                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (!countries.ContainsKey(continent))
                {
                    countries.Add(continent, new Dictionary<string, List<string>>());

                }
                if (!countries[continent].ContainsKey(country))
                {
                    countries[continent].Add(country, new List<string>());
                }

                countries[continent][country].Add(city);
            }
            foreach (var continent in countries)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (var country in continent.Value)
                {
                    Console.WriteLine($" {country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}

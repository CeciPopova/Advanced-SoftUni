using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace P04._Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
           string input = Console.ReadLine();
           IDictionary<string, Dictionary<string, double>> shopData= new Dictionary<string, Dictionary<string, double>>();  
            while (input!="Revision")
            {
                string[] inputArgs = input.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();  
                string shop = inputArgs[0]; 
                string product = inputArgs[1];  
                double price = double.Parse(inputArgs[2]);
                if (!shopData.ContainsKey(shop))
                {
                    shopData.Add(shop, new Dictionary<string, double>());   
                }
                shopData[shop].Add(product, price);

                input = Console.ReadLine();
            }
           
            foreach (var shop in shopData.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");

                }
            }
        }
    }
}

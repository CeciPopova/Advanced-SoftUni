using System;
using System.Collections.Generic;
using System.Linq;

namespace P04._Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
           Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (map.ContainsKey(num))
                {
                    map[num]++;
                }
                else
                {
                    map.Add(num, 1);
                }
            }
            foreach (var item in map)
            {
                if (item.Value%2==0)
                {
                    Console.WriteLine(item.Key);
                }
            }
            
        }
    }
}

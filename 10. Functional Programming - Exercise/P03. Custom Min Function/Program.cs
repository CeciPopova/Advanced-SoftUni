using System;
using System.Collections.Generic;
using System.Linq;

namespace P03._Custom_Min_Function
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            Func<List<int>,int> getMinElement = nums => nums.Min();
            Console.WriteLine(getMinElement(nums));
        }
    }
}

﻿using System;
using System.Collections.Generic;

namespace P01._Unique_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int n = int.Parse(Console.ReadLine());
            HashSet<string> set = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string username = Console.ReadLine();
                set.Add(username);  
            }
            foreach (var name in set)
            {
                Console.WriteLine(name);
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace P08._SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
           string input = Console.ReadLine();
            HashSet<string> vipPartyList = new HashSet<string>();  
            HashSet<string> regularPartyList = new HashSet<string>();   
            while (input!="PARTY")
            {
                if (input.Length==8 && char.IsDigit(input[0]))
                {
                    vipPartyList.Add(input);
                }
                else if (input.Length==8)
                {
                    regularPartyList.Add(input);    
                }
                input = Console.ReadLine(); 
            }
            string guest = Console.ReadLine();  
            while (guest!="END")
            {
                if (vipPartyList.Contains(guest))
                {
                    vipPartyList.Remove(guest);
                }
                else if (regularPartyList.Contains(guest))
                {
                    regularPartyList.Remove(guest);
                }

                guest=Console.ReadLine();
            }
            int total = vipPartyList.Count+regularPartyList.Count;
            Console.WriteLine(total);
            if (vipPartyList.Count>0)
            {
                foreach (var item in vipPartyList)
                {
                    Console.WriteLine(item);
                }
            }
            if (regularPartyList.Count>0)
            {
                foreach (var item in regularPartyList)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}

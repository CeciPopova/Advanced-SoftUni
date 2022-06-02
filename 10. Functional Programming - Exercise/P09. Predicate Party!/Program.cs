using System;
using System.Collections.Generic;
using System.Linq;

namespace P09._Predicate_Party_
{
    internal class Program
    {
        static void Main(string[] args)
        {
           List<string> people = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            string command = Console.ReadLine();

            while (command!="Party!")
            {
                Predicate<string> predicate = GetPredicate(command);
                string[] cmndArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = cmndArgs[0];


                if (action=="Double")
                {
                    for (int i = 0; i < people.Count; i++)
                    {
                        string person = people[i];

                        if (predicate(person))
                        {
                            people.Insert(i+1, person);  
                            i++;
                        }
                    }
                }
                else if (action=="Remove")
                {
                    people.RemoveAll(predicate);

                }


                command = Console.ReadLine();
            }
            if (people.Count>0)
            {
                Console.WriteLine($"{string.Join(", ", people)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            
        }
        private static Predicate<string> GetPredicate(string command)
        {
            string[] cmndArgs= command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string actionArg = cmndArgs[1];
            string arg = cmndArgs[2];
            Predicate<string> predicate = null;
            if (actionArg == "StartsWith")
            {
                predicate = name => name.StartsWith(arg);
            }
            else if (actionArg == "EndsWith")
            {
                predicate = name => name.EndsWith(arg);
            }
            else if (actionArg == "Length")
            {
                predicate = name => name.Length==int.Parse(arg) ;
            }
            return predicate;
        }
    }
}

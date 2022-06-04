using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
           int n = int.Parse(Console.ReadLine());
            List<Person> persons = new List<Person>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] personData = input.Split(' '); 
                string name = personData[0];    
                int age = int.Parse(personData[1]); 
                Person person = new Person(name,age);
                persons.Add(person);
            }
            persons= persons.OrderBy(p=>p.Name).Where(p=>p.Age>30).ToList();
            foreach (var person in persons)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
          
        }
    }
}

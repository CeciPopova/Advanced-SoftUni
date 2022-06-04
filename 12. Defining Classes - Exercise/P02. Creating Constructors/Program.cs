using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person firstPersin = new Person();  
            Person secondPersin = new Person(7);
            Person thirdPersin = new Person("Victor",9);

            Console.WriteLine($"First person is {firstPersin.Name} - {firstPersin.Age} years old!");
            Console.WriteLine($"Second person is {secondPersin.Name} - {secondPersin.Age} years old!");
            Console.WriteLine($"Third person is {thirdPersin.Name} - {thirdPersin.Age} years old!");
            
        }
    }
}

using System;
using System.Collections.Generic;

namespace P05._Filter_By_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ");
                students.Add(new Student(input[0], int.Parse(input[1])));
            }

            string condition = Console.ReadLine();
            int ageFilter = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            for (int i = 0; i < students.Count; i++)
            {
                Student student = students[i];
                if (condition=="older")
                {
                    if (student.Age >= ageFilter)
                    {
                        if (format == "name")
                        {
                            Console.WriteLine(student.Name);
                        }
                        else if (format == "age")
                        {
                            Console.WriteLine(student.Age);
                        }
                        else if (format == "name age")
                        {
                            Console.WriteLine($"{student.Name} - {student.Age}");
                        }
                    }
                }
                else if (condition=="younger")
                {
                    if (student.Age < ageFilter)
                    {
                        if (format == "name")
                        {
                            Console.WriteLine(student.Name);
                        }
                        else if (format == "age")
                        {
                            Console.WriteLine(student.Age);
                        }
                        else if (format == "name age")
                        {
                            Console.WriteLine($"{student.Name} - {student.Age}");
                        }
                    }
                }
            }
        }

    }
    class Student
    {
        public Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;

        }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}

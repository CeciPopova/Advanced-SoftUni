using System;
using System.Collections.Generic;

namespace P08._Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfCarToCross=int.Parse(Console.ReadLine());    
            string input = Console.ReadLine();
            Queue<string> queue = new Queue<string>();
            int count = 0;
            while (input!="end")
            {
                if (input!="green")
                {
                    queue.Enqueue(input);
                }
                else
                {
                    if (countOfCarToCross>queue.Count)
                    {
                        for (int i = 0; i < queue.Count; i++)
                        {
                            Console.WriteLine($"{queue.Dequeue()} passed!");
                            count++;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < countOfCarToCross; i++)
                        {
                            Console.WriteLine($"{queue.Dequeue()} passed!");
                            count++;
                        }
                    }
                 
                }
                

                input = Console.ReadLine();
            }
            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}

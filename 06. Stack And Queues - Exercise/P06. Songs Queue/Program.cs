using System;
using System.Collections.Generic;

namespace P06._Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
           string[] songs = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            Queue<string> queue = new Queue<string>(songs);
            string command = Console.ReadLine();
            while (queue.Count>0)
            {
                string[] cmndArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = cmndArgs[0];    
                if (action=="Play")
                {
                    if (queue.Count > 0)
                    {
                        queue.Dequeue();
                    }
                    else
                    {
                      
                        break;
                    }
                 
                }
                else if (action=="Add")
                {
                    string currSong = string.Empty;
                    for (int i = 1; i < cmndArgs.Length; i++)
                    {
                        if (i<cmndArgs.Length-1)
                        {
                            currSong += cmndArgs[i] + " ";
                        }
                        else
                        {
                            currSong += cmndArgs[i];
                        }
                      
                        
                    }
                    if (!queue.Contains(currSong))
                    {
                        queue.Enqueue(currSong);
                    }
                    else
                    {
                        Console.WriteLine($"{currSong} is already contained!");
                    }
                }
                else if (action=="Show")
                {
                    if (queue.Count>0)
                    {
                        Console.WriteLine(string.Join(", ", queue));
                    }
                  
                }

              
                command = Console.ReadLine();
            }
            Console.WriteLine("No more songs!");

        }
    }
}

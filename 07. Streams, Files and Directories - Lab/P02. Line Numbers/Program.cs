using System;
using System.IO;

namespace P02._Line_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
           using StreamReader reader = new StreamReader(@"C:\Temp\input.txt");
           using StreamWriter writer = new StreamWriter(@"C:\Temp\output.txt");

            int count = 1;
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                writer.WriteLine($"{count}. {line}");
                Console.WriteLine($"{count}. {line}");
                count++;    
            }
        }
    }
}

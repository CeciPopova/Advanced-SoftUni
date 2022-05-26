using System;
using System.IO;

namespace P01._Odd_Lines
{
    internal class Program
    {
        public class OddLines
        {
            static void Main()
            {
                using StreamReader reader = new StreamReader(@"input.txt");

                using StreamWriter writer = new StreamWriter(@"C:\Temp\output.txt");

                int index = 0;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (index % 2 == 1)
                    {
                        writer.WriteLine(line);
                        Console.WriteLine(line);
                    }
                    index++;
                }
            }
        }
    }
}

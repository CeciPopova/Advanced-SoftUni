
namespace OddLines
{
    using System;
    using System.IO;
    public class OddLines
    {
        static void Main()
        {
            string inputPath = @"..\..\..\input.txt";
            string outputPath = @"..\..\..\output.txt";

            ExtractOddLines(inputPath, outputPath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {

            using (StreamReader reader = new StreamReader(@"input.txt"))
            {
                using (StreamWriter writer = new StreamWriter(@"../../../output.txt"))
                {
                    int counter = 0;
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        if (counter % 2 == 0)
                        {
                            writer.WriteLine(line);
                            Console.WriteLine(line);
                        }
                        counter++;
                    }
                }
            }
        }
    }
}
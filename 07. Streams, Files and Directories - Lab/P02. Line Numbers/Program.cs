
namespace LineNumbers
{
    using System.IO;
    public class LineNumbers
    {
        static void Main(string[] args)
        {
            string inputPath = @"..\..\..\input.txt";
            string outputPath = @"..\..\..\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);

        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            using StreamReader reader = new StreamReader(@"input.txt");
            using StreamWriter writer = new StreamWriter(@"output.txt");

            int count = 1;
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                writer.WriteLine($"{count}. {line}");
               
                count++;
            }
        }
    }
}

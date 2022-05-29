namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            ProcessLines(inputFilePath);
        }

        public static string ProcessLines(string inputFilePath)
        {

            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                int count = 0;
                string line = reader.ReadLine();
                while (line != null)
                {
                    if (count % 2 == 0)
                    {
                        line = Replace(line);
                        line = ReverseLine(line);
                        Console.WriteLine(line);

                    }

                    line = reader.ReadLine();
                    count++;
                }
                return line;
            }

        }
        private static string ReverseLine(string line)
        {
            return string.Join(" ", line.Split(' ').Reverse());
        }
        private static string Replace(string line)
        {
            return line.Replace("-", "@")
                .Replace(",", "@")
                .Replace(".", "@")
                .Replace("!", "@")
                .Replace("?", "@");
        }
    }
}

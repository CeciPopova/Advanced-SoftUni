namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Text.RegularExpressions;
    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            throw new NotImplementedException();
            string[] lines = File.ReadAllLines("text.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                int letters = Regex.Matches(lines[i], "[A-Za-z]").Count;
                int punctuationMarks = Regex.Matches(lines[i], "[-,!.'?]").Count;
                string transformedLine = $"Line{i + 1}: {lines[i]} ({letters})({punctuationMarks})";

                File.AppendAllText("../../../output.txt", transformedLine + Environment.NewLine);
            }
        }
    }
}

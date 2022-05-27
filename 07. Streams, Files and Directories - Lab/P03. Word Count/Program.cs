namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    public class WordCount
    {
        static void Main(string[] args)
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {

            using (StreamReader reader = new StreamReader("words.txt"))
            {
                Dictionary<string, int> wordsCount = new Dictionary<string, int>();
                HashSet<string> words = reader.ReadToEnd()
                                              .Split(new string[] { " ", "\t", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                                              .Select(word => word.ToLower())
                                              .ToHashSet();
                foreach (string word in words)
                {
                    if (!wordsCount.ContainsKey(word))
                    {
                        wordsCount[word] = 0;
                    }
                }

                using (StreamReader reader2 = new StreamReader("text.txt"))
                {
                    string[] textWords = reader2.ReadToEnd()
                                                .Split(new string[] { " ", "\t", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                                                .Select(word => Regex.Match(word, @"[A-Za-z']*[A-Za-z]{1}").Value.ToLower())
                                                .ToArray();

                    foreach (string word in textWords)
                    {
                        if (wordsCount.ContainsKey(word))
                        {
                            wordsCount[word]++;
                        }
                    }
                }

                using (StreamWriter writer = new StreamWriter("../../../output.txt"))
                {
                    foreach (var word in wordsCount.OrderByDescending(w => w.Value))
                    {
                        writer.WriteLine($"{word.Key} - {word.Value}");
                    }
                }
            }

        }
    }
}
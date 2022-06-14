using System;
using System.Collections.Generic;
using System.Linq;

namespace P01._Food_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] input1 = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
            char[] input2 = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
            Queue<char> vowels = new Queue<char>(input1);
            Stack<char> consonants = new Stack<char>(input2);
            Dictionary<string, List<char>> words = new Dictionary<string, List<char>>
            {
                {"pear",new List<char>()},
                {"flour",new List<char>()},
                {"pork",new List<char>()},
                {"olive", new List<char>()}
            };
            while (consonants.Any())
            {
                char currVowel = vowels.Dequeue();
                char currConsonant = consonants.Pop();
                foreach (var word in words)
                {
                    if (word.Key.Contains(currVowel) && word.Key.Contains(currConsonant))
                    {
                        if (!word.Value.Contains(currVowel))
                        {
                            word.Value.Add(currVowel);
                        }
                        word.Value.Add(currConsonant);
                    }
                    else if (word.Key.Contains(currVowel))
                    {
                        if (!word.Value.Contains(currVowel))
                        {
                            word.Value.Add(currVowel);
                        }
                    }
                    else if (word.Key.Contains(currConsonant))
                    {
                        word.Value.Add(currConsonant);
                    }
                }
                vowels.Enqueue(currVowel);
            }
            int count = 0;

            foreach (var word in words)
            {
                if (word.Key.Length == word.Value.Count)
                {
                    count++;
                }
            }
            Console.WriteLine($"Words found: {count}");
            foreach (var item in words)
            {
                if (item.Key.Length == item.Value.Count)
                {
                    Console.WriteLine(item.Key);
                }
            }
        }
    }
}

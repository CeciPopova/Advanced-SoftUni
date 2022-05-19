using System;
using System.Linq;

namespace P03._Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries).ToArray();
            Predicate<string> checker = w => Char.IsUpper(w[0]);
            text = text.Where(x => checker(x)).ToArray();

            foreach (var word in text)
            {
                Console.WriteLine(word);
            }
        }
    }
}

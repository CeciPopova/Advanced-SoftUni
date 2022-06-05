using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string startDate = Console.ReadLine();
            string endDate = Console.ReadLine();

            DateModifier difference = new DateModifier();
            TimeSpan diff = difference.GetTheDifference(startDate, endDate);
            Console.WriteLine(diff.Days.ToString());


        }
    }
}

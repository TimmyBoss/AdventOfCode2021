using AdventOfCode.Console.Task1;
using System;

namespace AdventOfCode.Task1.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numberCollection = new NumberCollection();
            var numbers = numberCollection.GetSumsOfThree();
            int? prevNumber = null;
            var largerCount = 0;

            foreach (var number in numbers)
            {
                if (prevNumber.HasValue)
                {
                    if (number > prevNumber)
                        largerCount++;
                }
                prevNumber = number;
            }

            System.Console.WriteLine(largerCount);
            System.Console.ReadLine();
        }
    }
}

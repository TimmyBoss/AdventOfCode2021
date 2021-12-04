using System;

namespace AdventOfCode.Task2.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var calculationService = new CalculationService();
            Console.WriteLine(calculationService.GetAnswer());
            Console.ReadLine();
        }
    }
}

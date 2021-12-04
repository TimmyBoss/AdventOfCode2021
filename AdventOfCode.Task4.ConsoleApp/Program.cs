using AdventOfCode.Shared;
using System;

namespace AdventOfCode.Task4.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = PuzzleInputReader.GetInput();

            foreach (var item in list)
            { 
                Console.WriteLine(item);
            }
        }
    }
}

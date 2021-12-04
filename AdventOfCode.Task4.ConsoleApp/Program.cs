using AdventOfCode.Shared;
using System;

namespace AdventOfCode.Task4.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = PuzzleInputReader.GetInput();
            var bingoGame = new BingoGame(list);

            var answer1 = bingoGame.Start();
            var answer2 = bingoGame.CheckLastWinner();
            Console.WriteLine(answer1);
            Console.WriteLine(answer2);
            Console.ReadLine();
        }
    }
}

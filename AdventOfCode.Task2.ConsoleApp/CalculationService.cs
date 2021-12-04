using AdventOfCode.Shared;
using System;
using System.Collections.Generic;

namespace AdventOfCode.Task2.ConsoleApp
{
    public class CalculationService
    {
        private List<string> _puzzleInput;

        public CalculationService()
        {
            _puzzleInput = PuzzleInputReader.GetInput();
        }

        public int GetAnswer()
        {
            var horizontalPosition = 0;
            var depth = 0;
            var aim = 0;

            foreach (var item in _puzzleInput)
            {
                var splittedItem = item.Split(' ');
                var direction = splittedItem[0];
                var steps = Convert.ToInt32(splittedItem[1]);

                if (direction == "forward")
                {
                    horizontalPosition += steps;
                    depth += steps * aim;
                }
                if (direction == "down")
                {
                  //  depth += steps;
                    aim += steps;
                }
                if (direction == "up")
                {
                  //  depth -= steps;
                    aim -= steps;
                }
            }

            var result = depth * horizontalPosition;

            return result;
        }
    }
}

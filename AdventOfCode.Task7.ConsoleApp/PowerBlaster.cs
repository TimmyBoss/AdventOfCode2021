using AdventOfCode.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Task7.ConsoleApp
{
    public class PowerBlaster : ITask
    {
        public readonly int max = 1000;
        public List<int> _inputNumbers;

        public long GetAnswer1()
        {
            var result = new int[max];

            for (int i = 0; i < max; i++)
            {
                foreach (var number in _inputNumbers)
                {
                    result[i] += Math.Abs(number - i);
                }
            }

            return result.ToList().Min(m => m);
        }

        public long GetAnswer2()
        {
            var result = new int[max];

            for (int i = 0; i < max; i++)
            {
                foreach (var number in _inputNumbers)
                {
                    var amount = Math.Abs(number - i);

                    for(int j = 1; j <=amount; j++)
                        result[i] += j;
                }
            }

            return result.ToList().Min(m => m);
        }

        public void SetupPuzzleInput(List<string> puzzleInput)
        {
            _inputNumbers = puzzleInput[0].Split(',').Select(int.Parse).ToList();
        }
    }
}

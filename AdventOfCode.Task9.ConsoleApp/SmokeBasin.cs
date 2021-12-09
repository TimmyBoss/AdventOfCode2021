using AdventOfCode.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Task9.ConsoleApp
{
    public class SmokeBasin : ITask
    {
        private List<List<int>> _mainBasin;

        public SmokeBasin()
        {
            _mainBasin = new List<List<int>>();
        }

        public long GetAnswer1()
        {
            var numbers = new List<int>();

            for (int i = 0; i < _mainBasin.Count; i++)
            {
                for (int j = 0; j < _mainBasin[i].Count; j++)
                {
                    var number = _mainBasin[i][j];

                    var left = j > 0 ? _mainBasin[i][j - 1] : 10;
                    var right = j < _mainBasin[i].Count - 1 ? _mainBasin[i][j + 1] : 10;
                    var up = i > 0 ? _mainBasin[i - 1][j] : 10;
                    var down = i < _mainBasin.Count - 1 ? _mainBasin[i + 1][j] : 10;

                    if (number < left && number < right && number < up && number < down)
                        numbers.Add(number);

                }
            }

            return numbers.Sum(s => s + 1);
        }

        public long GetAnswer2()
        {
            return 0;
        }

        public void SetupPuzzleInput(List<string> puzzleInput)
        {
            foreach (var item in puzzleInput)
            {
                var numberList = item.ToCharArray().Select(s => Convert.ToInt32(s.ToString())).ToList();
                _mainBasin.Add(numberList);
            }
        }

        private List<int> ConvertNumberStringToIntList(string numbers)
        {
            return numbers.ToCharArray().Select(s => Convert.ToInt32(s.ToString())).ToList();
        }

        public bool CheckIfLowest(int currentNumber, int prevNumber, int nextNumber, int upNumber, int downNumber)
        {

            return true;
        }

    }
}

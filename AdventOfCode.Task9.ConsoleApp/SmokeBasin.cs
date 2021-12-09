using AdventOfCode.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Task9.ConsoleApp
{
    public class SmokeBasin : ITask
    {
        private List<List<int>> _mainBasin;
        private Dictionary<string, int> _basins;
        private List<string> alreadySet;

        public SmokeBasin()
        {
            _mainBasin = new List<List<int>>();
            _basins = new Dictionary<string, int>();
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
                    {
                        alreadySet = new List<string>();
                        RecursiveHenk(i, j); 
                        _basins.Add($"{i}-{j}", alreadySet.Count());
                    }
                }
            }

            var orderedBasins = _basins.OrderByDescending(b => b.Value).Select(s => s.Value).ToList();

            return orderedBasins[0] * orderedBasins[1] * orderedBasins[2];
        }

        private int RecursiveHenk(int i, int j)
        {
            if (alreadySet.Any(a => a == $"{i}-{j}"))
                return 0;

            alreadySet.Add($"{i}-{j}");

            var left = j > 0 ? _mainBasin[i][j - 1] : 10;
            var right = j < _mainBasin[i].Count - 1 ? _mainBasin[i][j + 1] : 10;
            var up = i > 0 ? _mainBasin[i - 1][j] : 10;
            var down = i < _mainBasin.Count - 1 ? _mainBasin[i + 1][j] : 10;

            if (left < 9)
                RecursiveHenk(i, j - 1);
            if (right < 9)
                RecursiveHenk(i, j + 1);
            if (up < 9)
                RecursiveHenk(i-1, j);
            if (down < 9)
                RecursiveHenk(i+1, j);

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

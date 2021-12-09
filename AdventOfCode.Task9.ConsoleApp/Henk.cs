using AdventOfCode.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Task9.ConsoleApp
{
    public class Henk : ITask
    {
        private List<string> _inputNumbers;

        public long GetAnswer1()
        {
            var numbers = new List<int>();

            for (int i = 0; i < _inputNumbers.Count; i++)
            {
                var currentRow = _inputNumbers[i].ToCharArray().Select(s => Convert.ToInt32(s.ToString())).ToList();
                var prevRow = i > 0 ? _inputNumbers[i-1].ToCharArray().Select(s => Convert.ToInt32(s.ToString())).ToList() : null;
                var nextRow = i < _inputNumbers.Count -1 ? _inputNumbers[i + 1].ToCharArray().Select(s => Convert.ToInt32(s.ToString())).ToList() : null;

                for (int j = 0; j < currentRow.Count; j++)
                {
                    if (prevRow == null)
                    {
                        if (j == 0)
                        {
                            if (currentRow[j] < currentRow[j + 1] && currentRow[j] < nextRow[j])
                                numbers.Add(currentRow[j]);
                            continue;
                        }

                        if (j == currentRow.Count - 1)
                        {
                            if (currentRow[j] < currentRow[j - 1] && currentRow[j] < nextRow[j])
                                numbers.Add(currentRow[j]);
                            continue;
                        }

                        if (currentRow[j] < currentRow[j - 1] && currentRow[j] < currentRow[j + 1] && currentRow[j] < nextRow[j])
                            numbers.Add(currentRow[j]);
                        continue;
                    }

                    if (nextRow == null)
                    {
                        if (j == 0)
                        {
                            if (currentRow[j] < currentRow[j + 1] && currentRow[j] < prevRow[j])
                                numbers.Add(currentRow[j]);
                            continue;
                        }

                        if (j == currentRow.Count - 1)
                        {
                            if (currentRow[j] < currentRow[j - 1] && currentRow[j] < prevRow[j])
                                numbers.Add(currentRow[j]);
                            continue;
                        }

                        if (currentRow[j] < currentRow[j - 1] && currentRow[j] < currentRow[j + 1] && currentRow[j] < prevRow[j])
                            numbers.Add(currentRow[j]);
                        continue;
                    }

                    if (j == 0)
                    {
                        if (currentRow[j] < currentRow[j + 1] && currentRow[j] < prevRow[j] && currentRow[j] < nextRow[j])
                            numbers.Add(currentRow[j]);
                        continue;
                    }

                    if (j == currentRow.Count - 1)
                    {
                        if (currentRow[j] < currentRow[j - 1] && currentRow[j] < prevRow[j] && currentRow[j] < nextRow[j])
                            numbers.Add(currentRow[j]);
                        continue;
                    }

                    if (currentRow[j] < currentRow[j - 1] && currentRow[j] < currentRow[j + 1] && currentRow[j] < prevRow[j]
                        && currentRow[j] < nextRow[j])
                        numbers.Add(currentRow[j]);
                }

            }
            return numbers.Sum(s => s+1);
        }

        public long GetAnswer2()
        {
            return 0;
        }

        public void SetupPuzzleInput(List<string> puzzleInput)
        {
            _inputNumbers = puzzleInput;
        }
    }
}

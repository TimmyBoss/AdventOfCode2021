using AdventOfCode.Shared;
using System;
using System.Collections.Generic;

namespace AdventOfCode.Task11.ConsoleApp
{
    public class DumboOctopus : ITask
    {
        private int _steps;
        public List<List<int>> _puzzleInputOne;
        public List<List<int>> _puzzleInputTwo;
        private int _flashAmount = 0;

        private List<string> _shouldFlashList = new List<string>();

        public long GetAnswer1()
        {
            _steps = 100;
            var puzzleInputWorkCopy = new List<List<int>>();
            puzzleInputWorkCopy.AddRange(_puzzleInputOne);

            for (int i = 1; i <= _steps; i++)
            {
                _shouldFlashList = new List<string>();
                for (var y = 0; y < puzzleInputWorkCopy.Count; y++)
                    for (var x = 0; x < puzzleInputWorkCopy[y].Count; x++)
                    {
                        if (puzzleInputWorkCopy[y][x] < 9)
                            puzzleInputWorkCopy[y][x]++;
                        else
                            _shouldFlashList.Add($"{y}-{x}");
                    }

                for (var y = 0; y < puzzleInputWorkCopy.Count; y++)
                {
                    for (var x = 0; x < puzzleInputWorkCopy[y].Count; x++)
                    {
                        if (_shouldFlashList.Contains($"{y}-{x}"))
                        {
                            puzzleInputWorkCopy[y][x] = 0;
                            _flashAmount++;
                            IncreaseAdjacentTiles(puzzleInputWorkCopy, y, x);
                        }
                    }
                }
            }

            return _flashAmount;
        }

        public long GetAnswer2()
        {
            _steps = 1000;
            var puzzleInputWorkCopy = new List<List<int>>();
            puzzleInputWorkCopy.AddRange(_puzzleInputTwo);

            for (int i = 1; i <= _steps; i++)
            {
                _shouldFlashList = new List<string>();
                for (var y = 0; y < puzzleInputWorkCopy.Count; y++)
                    for (var x = 0; x < puzzleInputWorkCopy[y].Count; x++)
                    {
                        if (puzzleInputWorkCopy[y][x] < 9)
                            puzzleInputWorkCopy[y][x]++;
                        else
                            _shouldFlashList.Add($"{y}-{x}");
                    }

                for (var y = 0; y < puzzleInputWorkCopy.Count; y++)
                {
                    for (var x = 0; x < puzzleInputWorkCopy[y].Count; x++)
                    {
                        if (_shouldFlashList.Contains($"{y}-{x}"))
                        {
                            puzzleInputWorkCopy[y][x] = 0;
                            _flashAmount++;
                            IncreaseAdjacentTiles(puzzleInputWorkCopy, y, x);
                        }
                    }
                }

                if (puzzleInputWorkCopy.TrueForAll(l => l.TrueForAll(l => l == 0)))
                    return i;
            }

            return 0;
        }

        public void SetupPuzzleInput(List<string> puzzleInput)
        {
            _puzzleInputOne = PuzzleInputReader.ConvertToNumberGrid(puzzleInput);
            _puzzleInputTwo = PuzzleInputReader.ConvertToNumberGrid(puzzleInput);
        }

        private void IncreaseAdjacentTiles(List<List<int>> list, int y, int x)
        {
            if (x > 0)
                SetValue(list, y, x - 1);
            if (x < list[y].Count-1)
                SetValue(list, y, x + 1);
            if (y > 0)
            {
                SetValue(list, y - 1, x);
         
                if (x > 0)
                    SetValue(list, y - 1, x - 1);
                if (x < list[y].Count-1)
                    SetValue(list, y - 1, x + 1);
            }
            if (y < list.Count-1)
            {
                SetValue(list, y + 1, x);

                if (x > 0)
                    SetValue(list, y + 1, x -1);
                if (x < list[y].Count-1)
                    SetValue(list, y + 1, x + 1);
            }
        }

        private void SetValue(List<List<int>> list, int y, int x)
        {
            if (list[y][x] > 0)
            {
                if (list[y][x] == 9)
                {
                    list[y][x] = 0;
                    _flashAmount++;
                    IncreaseAdjacentTiles(list, y, x);
                    _shouldFlashList.Remove($"{y}-{x}");
                }
                else
                    list[y][x]++;
            }
        }

        private void WriteGrid(List<List<int>> grid)
        {
            for (var y = 0; y < grid.Count; y++)
            {
                var xRow = "";
                for (var x = 0; x < grid[y].Count; x++)
                {
                    xRow += grid[y][x];
                }

                Console.WriteLine(xRow);
            }

            Console.WriteLine("");
        }
    }
}

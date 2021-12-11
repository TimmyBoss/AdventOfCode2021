using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Shared
{
    public class PuzzleInputReader
    {
        public static List<string> GetInput()
        {
            return File.ReadAllLines($"PuzzleInput.txt").ToList();
        }

        public static List<List<int>> ConvertToNumberGrid(List<string> puzzleInput)
        {
            var result = new List<List<int>>();

            foreach (var item in puzzleInput)
            {
                var numberList = item.ToCharArray().Select(s => Convert.ToInt32(s.ToString())).ToList();
                result.Add(numberList);
            }

            return result;
        }
    }
}

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
    }
}

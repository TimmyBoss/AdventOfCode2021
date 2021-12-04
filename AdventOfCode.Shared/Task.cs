using System;
using System.Collections.Generic;

namespace AdventOfCode.Shared
{

    public class Task<T> where T : ITask, new()
    {
        private readonly List<string> _puzzleInput;

        public Task()
        {
            _puzzleInput = PuzzleInputReader.GetInput(); 
        }

        public void ReadAnswers()
        {
            var t = new T();
            t.SetupPuzzleInput(_puzzleInput);
            Console.WriteLine($"Answer 1 = {t.GetAnswer1()}");
            Console.WriteLine($"Answer 2 = {t.GetAnswer2()}");
            Console.ReadLine();
        }
    }
}

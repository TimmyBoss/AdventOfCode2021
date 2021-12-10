using AdventOfCode.Shared;
using System.Collections.Generic;

namespace AdventOfCode.Task10.ConsoleApp
{

    public class SyntaxChecker : ITask
    {
        private List<string> _puzzleInput;

        public long GetAnswer1()
        {
            var invalidSyntaxList = new List<string>();
            foreach (var item in _puzzleInput)
            {
                if (item.ToCharArray().Length % 2 == 0)
                    invalidSyntaxList.Add(item);
            
            }

            return 0;
        }

        public long GetAnswer2()
        {
            return 0;
        }

        public void SetupPuzzleInput(List<string> puzzleInput)
        {
            _puzzleInput = puzzleInput;
        }
    }
}

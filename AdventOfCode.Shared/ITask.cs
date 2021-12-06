using System.Collections.Generic;

namespace AdventOfCode.Shared
{
    public interface ITask
    {
        void SetupPuzzleInput(List<string> puzzleInput);
        long GetAnswer1();
        long GetAnswer2();
    }
}

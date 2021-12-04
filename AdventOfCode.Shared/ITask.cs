using System.Collections.Generic;

namespace AdventOfCode.Shared
{
    public interface ITask
    {
        void SetupPuzzleInput(List<string> puzzleInput);
        int GetAnswer1();
        int GetAnswer2();
    }
}

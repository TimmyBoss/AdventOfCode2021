using AdventOfCode.Shared;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Task1.ConsoleApp
{
    public class SonarSweeper : ITask
    {
        private List<int> _depthList;

        public SonarSweeper() { }

        public int GetAnswer1()
        {
            var increasedCount = 0;
            int? prevDepth = null;

            foreach (var depth in _depthList)
            {
                if (prevDepth.HasValue)
                {
                    if (prevDepth < depth)
                        increasedCount++;
                }

                prevDepth = depth;
            }

            return increasedCount;
        }

        public int GetAnswer2()
        {
            return 0;
        }

        public void SetupPuzzleInput(List<string> puzzleInput)
        {
            _depthList = puzzleInput.Select(int.Parse).ToList();
        }
    }
}

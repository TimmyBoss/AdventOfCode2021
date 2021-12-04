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
            return GetIncreasedCount(_depthList);
        }

        public int GetAnswer2()
        {
            var measurementWindows = new List<int>();
            int counter = 0;

            while (counter < _depthList.Count-2)
            {
                var n1 = _depthList[counter];
                var n2 = _depthList[counter + 1];
                var n3 = _depthList[counter + 2];
                measurementWindows.Add(n1 + n2 + n3);
                counter++;
            }

            return GetIncreasedCount(measurementWindows);
        }

        public void SetupPuzzleInput(List<string> puzzleInput)
        {
            _depthList = puzzleInput.Select(int.Parse).ToList();
        }

        private int GetIncreasedCount(List<int> depthList)
        {
            var increasedCount = 0;
            int? prevDepth = null;

            foreach (var depth in depthList)
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
    }
}

using AdventOfCode.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Task6.ConsoleApp
{
    public class LanternFishGrower : ITask
    {
        private List<int> _initialState;

        public long GetAnswer1()
        {
            return GetAmountOfFish(80);
        }

        public long GetAnswer2()
        {
            return GetAmountOfFish(255);
        }

        private long GetAmountOfFish(int days)
        {
            var fishWithDaysLeft = new long[9];
            long zeros = 0;

            for (int n = 1; n < 9; n++)
                fishWithDaysLeft[n] = _initialState.Count(i => i == n);

            for (int d = 0; d < days; d++)
            {
                for (int n = 1; n < 9; n++)
                    fishWithDaysLeft[n - 1] = fishWithDaysLeft[n];

                fishWithDaysLeft[6] += zeros;
                fishWithDaysLeft[8] = zeros;
                zeros = 0;

                if (fishWithDaysLeft[0] > 0)
                {
                    zeros = fishWithDaysLeft[0];
                    fishWithDaysLeft[0] = 0;
                }
            }

            long sum = 0;
            for (int n = 0; n < 9; n++)
                sum += fishWithDaysLeft[n];

            return sum + zeros;
        }

        public void SetupPuzzleInput(List<string> puzzleInput)
        {

            _initialState = puzzleInput[0].Split(',').Select(int.Parse).ToList();
        }
    }
}

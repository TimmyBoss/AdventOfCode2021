using AdventOfCode.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Task3.ConsoleApp
{
    public class DiagnosticReport : ITask
    {
        private readonly int binaryLength = 12;

        private List<string> _binaryNumbers;

        public int GetAnswer1()
        {
            var gammaRate = "";
            var epsilonRate = "";

            for (int i = 0; i < binaryLength; i++)
            {
                var ones = _binaryNumbers.Count(b => b[i] == '1');
                var zeros = _binaryNumbers.Count(b => b[i] == '0');

                gammaRate += ones > zeros ? "1" : "0";
                epsilonRate += ones > zeros ? "0" : "1";
            }

            var gammaDecimal = Convert.ToInt32(gammaRate, 2);
            var epsilonDecimal = Convert.ToInt32(epsilonRate, 2);

            return gammaDecimal * epsilonDecimal;
        }

        public int GetAnswer2()
        {
            return 0;
        }

        public void SetupPuzzleInput(List<string> puzzleInput)
        {
            _binaryNumbers = puzzleInput;
        }
    }
}

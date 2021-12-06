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

        public long GetAnswer1()
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

        public long GetAnswer2()
        {
            var workList = new List<string>();
            workList.AddRange(_binaryNumbers);
            var oxygenRating = "";
            var scrubberRating = "";

            for (int i = 0; i < binaryLength; i++)
            {
                var ones = workList.Count(b => b[i] == '1');
                var zeros = workList.Count(b => b[i] == '0');

                if (ones >= zeros)
                    workList.RemoveAll(r => r[i] == '0');
                else
                    workList.RemoveAll(r => r[i] == '1');

                if (workList.Count == 1)
                {
                    oxygenRating = workList.First();
                    break;
                }
            }

            workList = new List<string>();
            workList.AddRange(_binaryNumbers);

            for (int i = 0; i < binaryLength; i++)
            {
                var ones = workList.Count(b => b[i] == '1');
                var zeros = workList.Count(b => b[i] == '0');

                if (ones >= zeros)
                    workList.RemoveAll(r => r[i] == '1');
                else
                    workList.RemoveAll(r => r[i] == '0');

                if (workList.Count == 1)
                {
                    scrubberRating = workList.First();
                    break;
                }
            }

            var oxygenDecimal = Convert.ToInt32(oxygenRating, 2);
            var scrubberDecimal = Convert.ToInt32(scrubberRating, 2);

            return oxygenDecimal * scrubberDecimal;
        }

        public void SetupPuzzleInput(List<string> puzzleInput)
        {
            _binaryNumbers = puzzleInput;
        }
    }
}

using AdventOfCode.Shared;
using System.Collections.Generic;

namespace AdventOfCode.Task5.ConsoleApp
{
    public class HydrothermalVentNavigator : ITask
    {
        private VentField _ventField;
        private VentLines _ventLines;

        public long GetAnswer1()
        {
            _ventField = new VentField();
            var ventLines = _ventLines.GetHorizontalVerticalOnly();
            _ventField.DrawLines(ventLines);
            var overlapCount = _ventField.GetOverlapCount();
            return overlapCount;
        }

        public long GetAnswer2()
        {
            _ventField = new VentField();
            _ventField.DrawLines(_ventLines);
            var overlapCount = _ventField.GetOverlapCount();
            return overlapCount;
        }

        public void SetupPuzzleInput(List<string> puzzleInput)
        {
            _ventLines = new VentLines(puzzleInput);
        }
    }
}

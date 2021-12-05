using System;

namespace AdventOfCode.Task5.ConsoleApp
{
    public class VentLine
    {
        public VentLine(string ventLine)
        {
            var splitPositions = GetSplitPositions(ventLine);
            StartPosition = GetPosition(splitPositions[0]);
            EndPosition = GetPosition(splitPositions[1]);
        }

        public Position StartPosition { get; private set; }
        public Position EndPosition { get; private set; }

        private string[] GetSplitPositions(string ventLines)
        {
            var positions = ventLines.Split(" -> ");
            return positions;
        }

        private Position GetPosition(string position)
        {
            var positions = position.Split(",");
            var x = Convert.ToInt32(positions[0]);
            var y = Convert.ToInt32(positions[1]);

            return new Position(x, y);
        }

        public new string ToString() => $"{StartPosition.X},{StartPosition.Y} -> {EndPosition.X},{EndPosition.Y}";
    }
}

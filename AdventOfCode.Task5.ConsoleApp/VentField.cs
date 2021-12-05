using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Task5.ConsoleApp
{
    public class VentField : Dictionary<string, int>
    {
        public VentField() {}

        public void DrawLines(VentLines ventLines)
        {
            foreach (var ventLine in ventLines)
            {
                if (ventLine.StartPosition.X == ventLine.EndPosition.X)
                    DrawHorizontalLine(ventLine);            
                if (ventLine.StartPosition.Y == ventLine.EndPosition.Y)
                    DrawVerticalLine(ventLine);
                if (ventLine.StartPosition.Y != ventLine.EndPosition.Y &&
                    ventLine.StartPosition.X != ventLine.EndPosition.X)
                    DrawDiagonalLine(ventLine);
            }
        }

        private void DrawHorizontalLine(VentLine ventLine)
        {
            if (ventLine.StartPosition.Y < ventLine.EndPosition.Y)
            {
                for (var i = ventLine.StartPosition.Y; i <= ventLine.EndPosition.Y; i++)
                    TriggerFieldPosition(ventLine.StartPosition.X, i);
            }

            if (ventLine.StartPosition.Y > ventLine.EndPosition.Y)
            {
                for (var i = ventLine.EndPosition.Y; i <= ventLine.StartPosition.Y; i++)
                    TriggerFieldPosition(ventLine.StartPosition.X, i);
            }
        }

        private void DrawVerticalLine(VentLine ventLine)
        {
            if (ventLine.StartPosition.X < ventLine.EndPosition.X)
            {
                for (var i = ventLine.StartPosition.X; i <= ventLine.EndPosition.X; i++)
                    TriggerFieldPosition(i, ventLine.StartPosition.Y);
            }

            if (ventLine.StartPosition.X > ventLine.EndPosition.X)
            {
                for (var i = ventLine.EndPosition.X; i <= ventLine.StartPosition.X; i++)
                    TriggerFieldPosition(i, ventLine.StartPosition.Y);
            }
        }

        private void DrawDiagonalLine(VentLine ventLine)
        {
            var y = ventLine.StartPosition.Y;

            if (ventLine.StartPosition.X < ventLine.EndPosition.X)
            {
                for (var x = ventLine.StartPosition.X; x <= ventLine.EndPosition.X; x++)
                {
                    TriggerFieldPosition(x, y);
                    if (y > ventLine.EndPosition.Y)
                        y--;
                    else
                        y++;
                }
            }

            if (ventLine.StartPosition.X > ventLine.EndPosition.X)
            {
                for (var x = ventLine.StartPosition.X; x >= ventLine.EndPosition.X; x--)
                {
                    TriggerFieldPosition(x, y);
                    if (y > ventLine.EndPosition.Y)
                        y--;
                    else
                        y++;
                }
            }
        }

        public int GetOverlapCount()
        {
            return this.Count(f => f.Value > 1);
        }

        public void TriggerFieldPosition(int x, int y)
        {
            var key = $"{x},{y}";

            if (!ContainsKey(key))
                Add(key, 1); 
            else
                this[key]++;
        }
    }
}

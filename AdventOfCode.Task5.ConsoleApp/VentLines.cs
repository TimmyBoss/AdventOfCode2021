using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Task5.ConsoleApp
{
    public class VentLines : List<VentLine>
    {
        public VentLines(IEnumerable<VentLine> ventLines)
        {
            AddRange(ventLines); 
        }

        public VentLines(List<string> ventLines)
        {
            foreach (var ventLine in ventLines)
                Add(new VentLine(ventLine));
        }

        public VentLines GetHorizontalVerticalOnly()
        {
            return new VentLines(this.Where(v => v.StartPosition.X == v.EndPosition.X || 
                v.StartPosition.Y == v.EndPosition.Y));
        }
    }
}

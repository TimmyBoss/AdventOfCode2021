namespace AdventOfCode.Task5.ConsoleApp
{
    public class Position
    {
        public Position(int x, int y)
        {
            X = x;
            Y = y; 
        }

        public int X { get; private set; }
        public int Y { get; private set; }
    }
}

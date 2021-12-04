namespace AdventOfCode.Task2.ConsoleApp
{
    public class DirectionSteps
    {
        public DirectionSteps(string direction, int steps)
        {
            Direction = direction;
            Steps = steps;
        }

        public string Direction { get; private set; }
        public int Steps { get; private set; }
    }
}

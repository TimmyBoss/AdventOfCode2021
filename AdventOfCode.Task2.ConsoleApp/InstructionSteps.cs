namespace AdventOfCode.Task2.ConsoleApp
{
    public class InstructionSteps
    {
        public InstructionSteps(string instruction, int steps)
        {
            Instruction = instruction;
            Steps = steps;
        }

        public string Instruction { get; private set; }
        public int Steps { get; private set; }
    }
}

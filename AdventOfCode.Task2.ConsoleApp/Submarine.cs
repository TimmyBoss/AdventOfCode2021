using AdventOfCode.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Task2.ConsoleApp
{
    public class Submarine : ITask
    {
        private List<InstructionSteps> _instructionSteps;

        public Submarine() 
        {
            _instructionSteps = new List<InstructionSteps>();
        }

        public int GetAnswer1()
        {
            var position = 0;
            var depth = 0;

            foreach (var instructionStep in _instructionSteps)
            {
                if (instructionStep.Instruction == Instruction.Forward)
                    position += instructionStep.Steps;
                if (instructionStep.Instruction == Instruction.Up)
                    depth -= instructionStep.Steps;
                if (instructionStep.Instruction == Instruction.Down)
                    depth += instructionStep.Steps;
            }

            return position * depth;
        }

        public int GetAnswer2()
        {
            return 0;
        }

        public void SetupPuzzleInput(List<string> puzzleInput)
        {
            foreach (var item in puzzleInput)
            {
                var splittedItem = item.Split(' ');
                var direction = splittedItem[0];
                var steps = Convert.ToInt32(splittedItem[1]);

                _instructionSteps.Add(new InstructionSteps(direction, steps));
            }
        }
    }
}

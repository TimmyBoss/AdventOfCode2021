using AdventOfCode.Shared;
using System;
using System.Collections.Generic;

namespace AdventOfCode.Task2.ConsoleApp
{
    public class Submarine : ITask
    {
        private List<InstructionSteps> _instructionSteps;

        public Submarine() 
        {
            _instructionSteps = new List<InstructionSteps>();
        }

        public long GetAnswer1()
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

        public long GetAnswer2()
        {
            var position = 0;
            var depth = 0;
            var aim = 0;

            foreach (var instructionStep in _instructionSteps)
            {
                if (instructionStep.Instruction == Instruction.Forward)
                {
                    position += instructionStep.Steps;
                    depth += instructionStep.Steps * aim;
                }
                if (instructionStep.Instruction == Instruction.Up)
                    aim -= instructionStep.Steps;
                if (instructionStep.Instruction == Instruction.Down)
                    aim += instructionStep.Steps;
            }

            return depth * position;
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

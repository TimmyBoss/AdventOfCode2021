using AdventOfCode.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Task8.ConsoleApp
{
    public class DigitDeterminer : ITask
    {
        private Dictionary<string, string> _outputValues;
        public DigitDeterminer()
        {
            _outputValues = new Dictionary<string, string>();
        }

        public long GetAnswer1()
        {
            var amount = 0;

            foreach (var item in _outputValues.Values)
            {
                var patterns = item.Split(' ');

                foreach (var value in patterns)
                {
                    if (value.Length == 2 || value.Length == 4 || value.Length == 3 || value.Length == 7)
                        amount++;
                }

            }

            return amount;
        }

        public long GetAnswer2()
        {
            var finalNumber = 0;
            var number = "";

            foreach (var item in _outputValues)
            {
                number = "";
                var patterns = item.Key.Split(' ').ToList();
                var mappings = GetDigitMapping(patterns);
                
                var values = item.Value.Split(' ').ToList();
                var orderedValues = new List<string>();

                foreach (var value in values)
                    orderedValues.Add(string.Concat(value.OrderBy(c => c)));

                foreach (var value in orderedValues)
                {
                    var mapping = mappings.FirstOrDefault(f => f.Value == value);
                    number += mapping.Key.ToString();
                }
                finalNumber += Convert.ToInt32(number);


            }
            return finalNumber;
        }

        public void SetupPuzzleInput(List<string> puzzleInput)
        {
            foreach (var item in puzzleInput)
            {
                var splitted = item.Split(" | ");
                _outputValues.Add(splitted[0], splitted[1]);
            }
        }

        private Dictionary<int, string> GetDigitMapping(List<string> values)
        {
            var orderedValues = new List<string>();

            foreach (var value in values)
                orderedValues.Add(string.Concat(value.OrderBy(c => c)));

            var mappings = new Dictionary<int, string>();

            foreach (var value in orderedValues)
            {
                if (value.Count() == 2)
                    mappings.Add(1, value);
                if (value.Count() == 4)
                    mappings.Add(4, value);
                if (value.Count() == 3)
                    mappings.Add(7, value);
                if (value.Count() == 7)
                    mappings.Add(8, value);
            }

            foreach (var value in orderedValues.OrderByDescending(c => c.Count()))
            {
                if (value.Count() == 6)
                {
                    if (mappings[4].All(v => value.Contains(v)))
                    {
                        mappings.Add(9, value);
                        continue;
                    }
                    if (mappings[7].All(v => value.Contains(v)))
                    {
                        mappings.Add(0, value);
                        continue;
                    }
                    
                    mappings.Add(6, value);
                }

                if (value.Count() == 5)
                {
                    if (mappings[1].All(v => value.Contains(v)))
                    {
                        mappings.Add(3, value);
                        continue;
                    }
                    if (value.All(v => mappings[9].Contains(v)))
                    {
                        mappings.Add(5, value);
                        continue;
                    }

                    mappings.Add(2, value);
                }
            }


            return mappings;
        }
    }
}

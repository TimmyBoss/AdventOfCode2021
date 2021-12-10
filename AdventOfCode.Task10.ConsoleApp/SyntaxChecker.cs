using AdventOfCode.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Task10.ConsoleApp
{

    public class SyntaxChecker : ITask
    {
        private List<string> _puzzleInput;
        private Dictionary<string, int> _charList;


        private readonly char haakjeOpen = '(';
        private readonly char haakjeClosed = ')';
        private readonly char bracketOpen = '[';
        private readonly char bracketClosed = ']';
        private readonly char accoladeOpen = '{';
        private readonly char accodeladeClosed = '}';
        private readonly char henkOpen = '<';
        private readonly char henkClosed = '>';

        public SyntaxChecker()
        {
            _charList = new Dictionary<string, int>();
            _charList.Add(")", 3);
            _charList.Add("]", 57);
            _charList.Add("}", 1197);
            _charList.Add(">", 25137);
        }

        public long GetAnswer1()
        {
            var invalidSyntaxList = new List<string>();
            var haakjeCount = 0;
            var bracketCount = 0;
            var accoladeCount = 0;
            var henkCount = 0;

            foreach (var item in _puzzleInput)
            {
                var i = 0;
                var sb = new StringBuilder(item);

                while (i < sb.Length-1)
                {
                    if (sb[i] == haakjeOpen && sb[i + 1] == haakjeClosed)
                    {
                        sb.Remove(i, 2);
                        i = 0;
                    }
                    if (sb[i] == bracketOpen && sb[i + 1] == bracketClosed)
                    {
                        sb.Remove(i, 2);
                        i = 0;
                    }
                    if (sb[i] == accoladeOpen && sb[i + 1] == accodeladeClosed)
                    {
                        sb.Remove(i, 2);
                        i = 0;
                    }
                    if (sb[i] == henkOpen && sb[i + 1] == henkClosed)
                    {
                        sb.Remove(i, 2);
                        i = 0;
                    }

                    i++;     
                }

                if (sb.ToString().Contains(haakjeClosed) || sb.ToString().Contains(bracketClosed) ||
                    sb.ToString().Contains(accodeladeClosed) || sb.ToString().Contains(henkClosed)) 
                {
                    foreach (var c in sb.ToString())
                    {
                        if (c == ')')
                        {
                            haakjeCount++;
                            break;
                        }
                        if (c == ']')
                        {
                            bracketCount++;
                            break;
                        }
                        if (c == '}')
                        {
                            accoladeCount++;
                            break;
                        }
                        if (c == '>')
                        {
                            henkCount++;
                            break;
                        }
                    }
                    invalidSyntaxList.Add(item);
                }
            }

            return (haakjeCount*3) + (bracketCount*57) + (accoladeCount*1197) + (henkCount*25137);
        }

        public long GetAnswer2()
        {
            var incompleteSyntaxList = new List<long>();
            foreach (var item in _puzzleInput)
            {
                long sum = 0;
                var i = 0;
                var sb = new StringBuilder(item);

                while (i < sb.Length - 1)
                {
                    if (sb[i] == haakjeOpen && sb[i + 1] == haakjeClosed)
                    {
                        sb.Remove(i, 2);
                        i = 0;
                    }
                    if (sb[i] == bracketOpen && sb[i + 1] == bracketClosed)
                    {
                        sb.Remove(i, 2);
                        i = 0;
                    }
                    if (sb[i] == accoladeOpen && sb[i + 1] == accodeladeClosed)
                    {
                        sb.Remove(i, 2);
                        i = 0;
                    }
                    if (sb[i] == henkOpen && sb[i + 1] == henkClosed)
                    {
                        sb.Remove(i, 2);
                        i = 0;
                    }

                    i++;
                }

                if (!sb.ToString().Contains(haakjeClosed) && !sb.ToString().Contains(bracketClosed) &&
                    !sb.ToString().Contains(accodeladeClosed) && !sb.ToString().Contains(henkClosed))
                {
                    for (var c = sb.Length-1; c >= 0; c--)
                    {
                        if (sb[c].ToString() == "(")
                            sum = (sum * 5) + 1;
                        if (sb[c].ToString() == "[")
                            sum = (sum * 5) + 2;
                        if (sb[c].ToString() == "{")
                            sum = (sum * 5) + 3;
                        if (sb[c].ToString() == "<")
                            sum = (sum * 5) + 4;
                    }
                    incompleteSyntaxList.Add(sum);
                }
            }
            var sorted = incompleteSyntaxList.OrderBy(o => o).ToList();

            return sorted[sorted.Count / 2];
        }

        public void SetupPuzzleInput(List<string> puzzleInput)
        {
            _puzzleInput = puzzleInput;
        }
    }
}

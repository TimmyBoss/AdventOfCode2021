using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Task4.ConsoleApp
{
    public class BingoCard
    {
        public List<List<int>> _rows { get; set; }
        public List<List<int>> _columns { get; set; }

        public BingoCard(List<string> numberRows)
        {
            _rows = GetRows(numberRows);
            _columns = GetColumns(numberRows);
        }

        private List<List<int>> GetRows(List<string> numberRows)
        { 
            var rows = new List<List<int>>();

            foreach (var row in numberRows)
            {
                rows.Add(row.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
            }

            return rows;
        }
        private List<List<int>> GetColumns(List<string> numberRows)
        {
            var columns = new List<List<int>>();
            var rows = GetRows(numberRows);

            for (int i = 0; i < 5; i++)
            {
                var column = new List<int>();

                foreach (var row in rows)
                    column.Add(row[i]);

                columns.Add(column);
            }

            return columns;
        }

        public void MarkNumber(int number)
        {
            foreach (var row in _rows)
            {
                if (row.Contains(number))
                    row.Remove(number);
            }

            foreach (var column in _columns)
            {
                if (column.Contains(number))
                    column.Remove(number);
            }
        }

        public bool HasBingo()
        {
            return _columns.Any(c => c.Count == 0) || _rows.Any(c => c.Count == 0);
        }

        public int GetSum()
        {
            return _rows.Sum(r => r.Sum());
        }
    }
}

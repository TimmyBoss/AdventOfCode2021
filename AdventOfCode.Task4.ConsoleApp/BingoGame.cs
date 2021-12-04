using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Task4.ConsoleApp
{
    public class BingoGame
    {
        public BingoGame(List<string> puzzleInput)
        {
            Caller = new BingoNumberCaller(puzzleInput[0]);
            Cards = GetCards(puzzleInput);
        }

        public BingoNumberCaller Caller { get; private set; }

        public List<BingoCard> Cards { get; private set; }

        private List<BingoCard> GetCards(List<string> puzzleInput)
        {
            var cards = new List<BingoCard>();
            var numberRows = new List<string>();

            foreach(var item in puzzleInput)
            {
                if (puzzleInput[0] == item || item == "") continue;
                numberRows.Add(item);

                if (numberRows.Count == 5)
                {
                    cards.Add(new BingoCard(numberRows));
                    numberRows = new List<string>();
                }
            }

            return cards;
        }

        public int Start()
        {
            foreach (var number in Caller.Call())
            {
                var card = CheckCards(number);

                if (card != null)
                {
                    var sum = card.GetSum();
                    return sum * number;
                }
            }

            return 0;
        }

        public BingoCard CheckCards(int number)
        {
            foreach (var card in Cards)
            {
                card.MarkNumber(number);

                if (card.HasBingo())
                    return card;
            }

            return null;
        }
    }


}

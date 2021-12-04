using AdventOfCode.Shared;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Task4.ConsoleApp
{
    public class BingoGame : ITask
    {
        public BingoGame() { }

        public void SetupPuzzleInput(List<string> puzzleInput)
        {
            Caller = new BingoNumberCaller(puzzleInput[0]);
            Cards = GetCards(puzzleInput);
        }

        public int GetAnswer1()
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
        public int GetAnswer2()
        {
            foreach (var number in Caller.Call())
            {
                var cardNumbers = GetBingoCardNumbers(number);
                if (cardNumbers.Count() > 0)
                {
                    if (Cards.Count() == 1 && cardNumbers.Count() == 1)
                    {
                        return Cards.First().GetSum() * number;
                    }

                    Cards = Cards.Where(c => !cardNumbers.Contains(c.Number)).ToList();
                }
            }

            return 0;
        }

        public BingoNumberCaller Caller { get; private set; }
        public List<BingoCard> Cards { get; private set; }

        private List<BingoCard> GetCards(List<string> puzzleInput)
        {
            var cards = new List<BingoCard>();
            var numberRows = new List<string>();
            int cardNumber = 1;

            foreach(var item in puzzleInput)
            {
                if (puzzleInput[0] == item || item == "") continue;
                numberRows.Add(item);

                if (numberRows.Count == 5)
                {
                    cards.Add(new BingoCard(cardNumber, numberRows));
                    numberRows = new List<string>();
                    cardNumber++;
                }
            }

            return cards;
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

        public List<int> GetBingoCardNumbers(int number)
        {
            var cardNumbers = new List<int>();

            foreach (var card in Cards)
            {
                card.MarkNumber(number);

                if (card.HasBingo())
                    cardNumbers.Add(card.Number);
            }

            return cardNumbers;
        }
    }
}

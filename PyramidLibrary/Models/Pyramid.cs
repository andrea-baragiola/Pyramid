using PyramidLibrary.CustomExceptions;

namespace PyramidLibrary.Models
{
    public class Pyramid
    {
        private Card?[][] cardRows;
        private Dictionary<Card, Tuple<int, int>> cardPositionLookUp;

        public Pyramid(FullDeck deck, int numberOfRows)
        {
            cardRows = new Card?[numberOfRows][];
            int cardsToDrow = numberOfRows * (numberOfRows + 1) / 2;
            Stack<Card> cardsForPyramid = new Stack<Card>(deck.DrowCards(cardsToDrow).Reverse());

            FillPyramid(numberOfRows, cardsForPyramid);
        }

        private void FillPyramid(int numberOfRows, Stack<Card> cardsForPyramid)
        {

            for (int i = 0; i < numberOfRows; i++)
            {
                cardRows[i] = new Card[i + 1];
                for (int j = 0; j <= i; j++)
                {
                    var card = cardsForPyramid.Pop();
                    cardRows[i][j] = card;
                    cardPositionLookUp.Add(card, new Tuple<int, int>(i, j));
                }
            }
        }

        /// <summary>
        /// Peek a card from the pyramid without drowing it
        /// </summary>
        /// <param name="row">1 based index of the pyramid row. 1 is the small top one</param>
        /// <param name="col">1 based index of the pyramid col. 1 is the most left one in the row</param>
        /// <returns>The card or null of the card is already drown</returns>
        public Card? Peek(int row, int col)
        {
            try
            {
                return cardRows[row - 1][col - 1];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidCardPositionException();
            }
        }

        public bool CanDrow(Card card)
        {
            // get card position
            var cardPosition = cardPositionLookUp[card];
            // check if card is in last row
            if (cardPosition.Item1 == cardRows.Length - 1) return true;
            // check if in the next row in col and col+1 is empty
            if (cardRows[cardPosition.Item1 + 1][cardPosition.Item2] == null && cardRows[cardPosition.Item1 + 1][cardPosition.Item2 + 1] == null) return true;

            return false;
        }

        public void Drow(Card card)
        {
            // get card position
            var cardPosition = cardPositionLookUp[card];

            cardRows[cardPosition.Item1][cardPosition.Item2] = null;
        }
    }
}


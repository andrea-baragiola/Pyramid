using PyramidLibrary.CustomExceptions;
using PyramidLibrary.Models.Decks;

namespace PyramidLibrary.Models
{
    public class Pyramid
    {
        public List<List<Card?>> CardRows { get; }
        public Dictionary<Card, (int, int)> CardLookup { get; set; } = new();

        public Pyramid(IDeck deck, int numberOfRows)
        {
            CardRows = new();
            CreateCardRows(numberOfRows);
            FillPyramid(deck, numberOfRows);
        }

        private void CreateCardRows(int numberOfRows)
        {
            int rowIndex = 0;
            for (int i = 0; i < numberOfRows + 1; i++)
            {
                List<Card> cards = new();
                for (int j = 0; j < rowIndex + 1; j++)
                {
                    cards.Add(null);
                }
                CardRows.Add(cards);

                rowIndex++;
            }
        }

        private void FillPyramid(IDeck deck, int numberOfRows)
        {
            int numberOfCardsToDrow = numberOfRows * (numberOfRows + 1) / 2;
            List<Card> cardsForPyramid = new();
            for (int i = 0; i < numberOfCardsToDrow; i++)
            {
                deck.
            }

            List<Card> cardsForPyramid = deck.DrowCards(numberOfCardsToDrow).ToList();
            PlaceCardsInPyramid(numberOfRows, cardsForPyramid);
        }

        private void PlaceCardsInPyramid(int numberOfRows, List<Card> cardsForPyramid)
        {

            for (int j = 0; j < numberOfRows; j++)
            {
                int rowIndex = j;
                int cardIndex = 0;
                for (int i = 0; i <= rowIndex; i++)
                {

                    ReceiveCard(cardsForPyramid[0], rowIndex, cardIndex);
                    CardLookup.Add(cardsForPyramid[0], (rowIndex, cardIndex));
                    cardsForPyramid.RemoveAt(0);
                    cardIndex++;
                }
            }
        }

        public void RemoveCard(Card cardToGive)
        {
            var cohordinates = CardLookup[cardToGive];
            CardRows[cohordinates.Item1][cohordinates.Item2] = null;
        }

        private void ReceiveCard(Card card, int rowIndex, int cardIndex)
        {
            if (CardRows[rowIndex][cardIndex] != null)
            {
                throw new SpotNotNullException("Error: A not null card is already in this spot");
            }
            else
            {
                CardRows[rowIndex][cardIndex] = card;
            }
        }
    }
}

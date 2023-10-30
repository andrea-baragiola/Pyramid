using PyramidLibrary.CustomExceptions;

namespace PyramidLibrary.Models
{
    public class Pyramid
    {
        public List<List<Card?>> CardRows { get; private set; }

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
            int cardsToDrow = numberOfRows * (numberOfRows + 1) / 2;
            List<Card> cardsForPyramid = deck.DrowCards(cardsToDrow).ToList();
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
                    cardsForPyramid.RemoveAt(0);
                    cardIndex++;
                }
            }
        }

        public Card GiveCard(int rowIndex, int cardIndex)
        {
            Card outputCard = CardRows[rowIndex][cardIndex];
            CardRows[rowIndex][cardIndex] = null;
            return outputCard;
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

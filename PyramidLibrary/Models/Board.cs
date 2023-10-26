namespace PyramidLibrary.Models
{
    public class Board : IBoard
    {
        public Pyramid Pyramid { get; protected set; }
        public Deck Deck { get; protected set; }
        public DiscardDeck DiscardDeck { get; protected set; }

        public Board(int numberOfRows = 7)
        {
            Pyramid = new(numberOfRows);
            Deck = new();
            DiscardDeck = new();
            List<Card> cardsForPyramid = TakeCorrectAmountOfCardsFromDeck(numberOfRows);
            PlaceCardsInPyramid(numberOfRows, cardsForPyramid);
        }

        protected List<Card> TakeCorrectAmountOfCardsFromDeck(int numberOfRows)
        {
            List<Card> cards = new();
            int sum = 0;
            for (int i = 0; i < numberOfRows; i++)
            {
                sum = sum + 1 + i;
            }

            for (int i = 0; i < sum; i++)
            {
                cards.Add(Deck.GiveCard(0));
            }
            return cards;
        }

        protected void PlaceCardsInPyramid(int numberOfRows, List<Card> cardsForPyramid)
        {

            for (int j = 0; j < numberOfRows; j++)
            {
                int rowIndex = j;
                int cardIndex = 0;
                for (int i = 0; i <= rowIndex; i++)
                {

                    Pyramid.ReceiveCard(cardsForPyramid[0], rowIndex, cardIndex);
                    cardsForPyramid.RemoveAt(0);
                    cardIndex++;
                }
            }
        }
    }
}

namespace PyramidLibrary.Models
{
    public class CustomBoard : Board
    {
        public CustomBoard(int numberOfRows, Deck deck) : base(numberOfRows)
        {
            Pyramid = new(numberOfRows);
            Deck = deck;
            DiscardDeck = new();
            List<Card> cardsForPyramid = TakeCorrectAmountOfCardsFromDeck(numberOfRows);
            PlaceCardsInPyramid(numberOfRows, cardsForPyramid);
        }
    }
}

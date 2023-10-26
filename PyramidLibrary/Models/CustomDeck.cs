namespace PyramidLibrary.Models
{
    public class CustomDeck : Deck, IDeck
    {
        public CustomDeck(List<Card> cards)
        {
            _cards = cards;
        }
    }
}

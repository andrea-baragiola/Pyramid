namespace PyramidLibrary.Models.Decks;

public class CustomDeck : Deck
{
    public CustomDeck(Card[] oldCards)
    {
        Cards = oldCards.Select(card => new Card(card.Number, card.Suit, card.Name)).ToList();
    }
}

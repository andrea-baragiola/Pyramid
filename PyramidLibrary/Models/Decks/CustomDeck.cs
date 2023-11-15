namespace PyramidLibrary.Models.Decks;

public class CustomDeck : Deck
{
    // TODO:EDAR perche' usare una lista se non usi nessuna proprieta' intrinseca di list? Una lista implica che sfrutti qualcosa di mutabile, cosa che non avviene in questo caso
    public CustomDeck(IEnumerable<Card> oldCards)
    {
        Cards = oldCards.Select(card => new Card(card.Number, card.Suit, card.Name)).ToList();
    }
}

namespace PyramidLibrary.Models.Decks;

//public class CustomDeck : Deck, IDeck
//{
//    public CustomDeck(List<Card> oldcards)
//    {
//        Cards = oldcards;
//    }
//}

// TODO:EDAR Se estendi deck non c'e' bisogno di implementare anche IDeck, sfrutta la proprieta' transitiva.
public class CustomDeck : Deck, IDeck
{
    // TODO:EDAR perche' usare una lista se non usi nessuna proprieta' intrinseca di list? Una lista implica che sfrutti qualcosa di mutabile, cosa che non avviene in questo caso
    public CustomDeck(List<Card> oldCards)
    {
        Cards = oldCards.Select(card => new Card(card.Number, card.Suit, card.Name)).ToList();
    }
}

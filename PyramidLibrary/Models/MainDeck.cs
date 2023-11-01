namespace PyramidLibrary.Models;

public class MainDeck : IDeck
{

    public IEnumerable<Card> Cards => _cards;

    protected List<Card> _cards;

    public MainDeck(IDeck deck)
    {
        _cards = deck.Cards.ToList();
    }

    public void DrowCard(Card card)
    {
        _cards.Remove(card);
    }

}


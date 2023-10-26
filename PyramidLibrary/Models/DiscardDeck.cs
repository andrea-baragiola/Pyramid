namespace PyramidLibrary.Models;

public class DiscardDeck : IDeck
{

    public IEnumerable<Card> Cards => _cards;
    protected List<Card> _cards;

    public DiscardDeck()
    {
        _cards = new();
    }

    public void ReceiveCard(Card card)
    {
        _cards.Add(card);
    }
}


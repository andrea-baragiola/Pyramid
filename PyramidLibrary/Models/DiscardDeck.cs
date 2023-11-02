namespace PyramidLibrary.Models;

public class DiscardDeck : IDeck
{

    public List<Card> Cards => _cards;

    protected List<Card> _cards = new List<Card>();


    public void ReceiveCard(Card card)
    {
        _cards.Add(card);
    }

    public Card DrowCard()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Card> DrowCards(int numberOfCards)
    {
        throw new NotImplementedException();
    }

    public void GiveCard(int x)
    {
        throw new NotImplementedException();
    }
}


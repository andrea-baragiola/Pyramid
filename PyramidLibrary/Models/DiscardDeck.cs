namespace PyramidLibrary.Models;

public class DiscardDeck : IDeck
{

    public List<Card> Cards { get; set; }

    public DiscardDeck()
    {
        Cards = new();
    }

    public void ReceiveCard(Card card)
    {
        Cards.Add(card);
    }
}


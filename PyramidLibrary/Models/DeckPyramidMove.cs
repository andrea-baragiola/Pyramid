namespace PyramidLibrary.Models;

public class DeckPyramidMove
{

    public int DeckCardIndex { get; set; }

    public Card DeckCard { get; set; }
    public Card PyramidCard { get; set; }
    public DeckPyramidMove(Card deckCard, Card pyramidCard, int deckCardIndex )
    {
        DeckCard = deckCard;
        PyramidCard = pyramidCard;
        DeckCardIndex = deckCardIndex;
    }
}

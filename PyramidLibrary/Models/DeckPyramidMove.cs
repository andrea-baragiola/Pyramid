namespace PyramidLibrary.Models;

public class DeckPyramidMove
{

    public int DeckCardIndex { get; set; }
    public int PyramidCardRow { get; set; }
    public int PyramidCardIndex { get; set; }
    public Card DeckCard { get; set; }
    public Card PyramidCard { get; set; }
    public DeckPyramidMove(Card deckCard, Card pyramidCard, int deckCardIndex, int pyramidCardRow, int pyramidCardIndex)
    {
        DeckCard = deckCard;
        PyramidCard = pyramidCard;
        DeckCardIndex = deckCardIndex;
        PyramidCardRow = pyramidCardRow;
        PyramidCardIndex = pyramidCardIndex;
    }
}

namespace PyramidLibrary.Models.Moves;

public class DeckPyramidMove : IMove
{
    public string Description => $"{PyramidCard.Name} + {DeckCard.Name}";
    public int DeckCardIndex { get; set; }

    public Card DeckCard { get; set; }
    public Card PyramidCard { get; set; }
    public DeckPyramidMove(Card deckCard, Card pyramidCard, int deckCardIndex)
    {
        DeckCard = deckCard;
        PyramidCard = pyramidCard;
        DeckCardIndex = deckCardIndex;
    }
}

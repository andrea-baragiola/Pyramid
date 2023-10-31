namespace PyramidLibrary.Models;

public class DeckPyramidMove
{

    public int DeckCardIndex { get; set; }
    public int PyramidCardRow { get; set; }
    public int PyramidCardIndex { get; set; }
    public DeckPyramidMove(int deckCardIndex, int pyramidCardRow, int pyramidCardIndex)
    {
        DeckCardIndex = deckCardIndex;
        PyramidCardRow = pyramidCardRow;
        PyramidCardIndex = pyramidCardIndex;
    }
}

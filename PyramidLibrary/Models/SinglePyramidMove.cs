namespace PyramidLibrary.Models;

public class SinglePyramidMove
{
    public Card Card { get; set; }
    public int PyramidCardRow { get; set; }
    public int PyramidCardIndex { get; set; }

    public SinglePyramidMove(Card card, int pyramidCardRow, int pyramidCardIndex)
    {
        Card = card;
        PyramidCardRow = pyramidCardRow;
        PyramidCardIndex = pyramidCardIndex;
    }
}

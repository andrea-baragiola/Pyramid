namespace PyramidLibrary.Models;

public class PyramidPyramidMove
{
    public int PyramidCardRow1 { get; set; }
    public int PyramidCardIndex1 { get; set; }
    public int PyramidCardRow2 { get; set; }
    public int PyramidCardIndex2 { get; set; }
    public Card Card1 { get; set; }
    public Card Card2 { get; set; }
    public PyramidPyramidMove(Card card1, Card card2, int pyramidCardRow1, int pyramidCardIndex1, int pyramidCardRow2, int pyramidCardIndex2)
    {
        Card1 = card1;
        Card2 = card2;
        PyramidCardRow1 = pyramidCardRow1;
        PyramidCardIndex1 = pyramidCardIndex1;
        PyramidCardRow2 = pyramidCardRow2;
        PyramidCardIndex2 = pyramidCardIndex2;

    }
}

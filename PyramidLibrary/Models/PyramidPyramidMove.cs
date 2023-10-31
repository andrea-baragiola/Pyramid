namespace PyramidLibrary.Models;

public class PyramidPyramidMove
{
    public int PyramidCardRow1 { get; set; }
    public int PyramidCardIndex1 { get; set; }
    public int PyramidCardRow2 { get; set; }
    public int PyramidCardIndex2 { get; set; }
    public PyramidPyramidMove(int pyramidCardRow1, int pyramidCardIndex1, int pyramidCardRow2, int pyramidCardIndex2)
    {
        PyramidCardRow1 = pyramidCardRow1;
        PyramidCardIndex1 = pyramidCardIndex1;
        PyramidCardRow2 = pyramidCardRow2;
        PyramidCardIndex2 = pyramidCardIndex2;

    }
}

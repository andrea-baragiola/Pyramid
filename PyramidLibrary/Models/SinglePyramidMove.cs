namespace PyramidLibrary.Models;

public class SinglePyramidMove
{
    public int PyramidCardRow { get; set; }
    public int PyramidCardIndex { get; set; }

    public SinglePyramidMove(int pyramidCardRow, int pyramidCardIndex)
    {
        PyramidCardRow = pyramidCardRow;
        PyramidCardIndex = pyramidCardIndex;
    }
}

namespace PyramidLibrary.Models
{
    public interface IPyramid
    {
        List<List<Card?>> CardRows { get; }

        Card GiveCard(int rowIndex, int cardIndex);
    }
}
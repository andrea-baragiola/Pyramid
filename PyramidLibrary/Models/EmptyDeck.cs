namespace PyramidLibrary.Models;

public class EmptyDeck : IDeck
{
    public List<IPosition> Positions { get; set; }
    public EmptyDeck()
    {
        Positions = new();
    }
}

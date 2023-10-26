namespace PyramidLibrary.Models
{
    public interface IDeck
    {
        IEnumerable<Card> Cards { get; }
    }
}
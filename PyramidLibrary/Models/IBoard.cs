namespace PyramidLibrary.Models
{
    public interface IBoard
    {
        IDeck Deck { get; }
        IDeck DiscardDeck { get; }
        int Id { get; }
        IPyramid Pyramid { get; }
    }
}
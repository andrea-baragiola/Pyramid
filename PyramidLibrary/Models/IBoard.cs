namespace PyramidLibrary.Models
{
    public interface IBoard
    {
        IDeck Deck { get; }
        DiscardDeck DiscardDeck { get; }
        int Id { get; }
        Pyramid Pyramid { get; }
    }
}
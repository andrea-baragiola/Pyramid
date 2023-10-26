namespace PyramidLibrary.Models
{
    public interface IBoard
    {
        Deck Deck { get; }
        DiscardDeck DiscardDeck { get; }
        int Id { get; }
        Pyramid Pyramid { get; }
    }
}